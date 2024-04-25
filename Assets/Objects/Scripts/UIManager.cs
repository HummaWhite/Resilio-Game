using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void LoadGameLevel() {
        SceneManager.LoadScene(ValueShortcut.SceneName_Game);
    }

    public void QuitGame()
    {
       Application.Quit();
    }
}
