using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public string levelName = "Menu";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision){
        if(collision.collider.CompareTag("Player")){
            Physics.gravity = new Vector3(0,-9.8f,0);     
            SceneManager.LoadScene(levelName);
        }
    }
}
