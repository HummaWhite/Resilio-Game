using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlockable : MonoBehaviour
{
    public bool unlocked = false;

    protected virtual void UnlockBehavior() {}

    protected virtual void ResetBehavior() {}

    public void Unlock()
    {
        UnlockBehavior();
        unlocked = true;
    }

    public void Reset()
    {
        ResetBehavior();
        unlocked = false;
    }

    // Start is called before the first frame update
    void Start()
    {   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("Jump"))
        {
            Reset();
        }
    }
}
