using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance { get; private set;}

    [Header("Setting")]
    public ObjectPoolSetting[] objPoolsSettings;

    static Dictionary<string, ObjectPoolInfo> poolInfo = new Dictionary<string, ObjectPoolInfo>();
    static Dictionary<GameObject, string> poolObjs = new Dictionary<GameObject, string>();

    public void Init()
    {
        if(instance == null) { instance = this; }   

        CreatePoolObject();
    }

    void CreatePoolObject()
    {
        foreach(var objPool in objPoolsSettings)
        {
            GameObject poolParent = new GameObject(objPool.name);
            poolParent.transform.SetParent(transform);
            poolInfo.Add(objPool.name, new ObjectPoolInfo(poolParent.transform, objPool.prefab, objPool.enableInPool));

            for(int i = 0; i < objPool.quantity; i++)
            {                
                GameObject newObj = poolInfo[objPool.name].AddNewObj();
                poolObjs.Add(newObj, objPool.name);
            }
        }
    }

    public static Transform TakeFromPool(string pool)
    {
        Transform t = poolInfo[pool].Take();
   
        return t;
    }

    public static void ReturnToPool(GameObject obj)
    {
        poolInfo[poolObjs[obj]].Return(obj);
    }
}

[System.Serializable]
public struct ObjectPoolSetting
{
    public string name;
    public GameObject prefab;
    [Range(1, 30)] public int quantity;
    public bool enableInPool;
}

public class ObjectPoolInfo
{
    Transform pool;
    GameObject prefab;
    readonly bool enableInPool;

    public int totalObj;
    public int outObj;
    public int inObj;

    Dictionary<GameObject, bool> objList;
    public Coroutine corou;

    public ObjectPoolInfo(Transform pool, GameObject prefab, bool enableInPool)
    {
        this.pool = pool;
        this.prefab = prefab;
        this.enableInPool = enableInPool;

        objList = new Dictionary<GameObject, bool>();
    }

    public GameObject AddNewObj()
    {
        GameObject newObj = GameObject.Instantiate(prefab, pool.transform);
        newObj.SetActive(enableInPool);
        newObj.transform.position = pool.transform.position;
        newObj.name = $"{prefab.name} ({totalObj + 1})";
        objList.Add(newObj, false);
        totalObj++;
        inObj++;
        return newObj;
    }

    public Transform Take()
    {
        if(objList == null || objList.Count == 0 || inObj == 0)
        {
            return null;
        }

        Transform t = null;

        foreach(GameObject obj in objList.Keys)
        {
            if(!objList[obj])
            {
                outObj++;
                inObj--;
                objList[obj] = true;
                obj.SetActive(true);
                t = obj.transform;
                break;
            }
        }

        return t;
    }

    public void Return(GameObject obj)
    {
        if(!objList.ContainsKey(obj))
        {
            return;
        }

        outObj--;
        inObj++;
        obj.SetActive(false);
        obj.transform.SetParent(pool);        
        objList[obj] = false;
    }
}
