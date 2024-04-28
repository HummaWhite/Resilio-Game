using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject LevelSelection;
    void Start()
    {
        LevelSelection.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void LoadGameLevel() {
        SceneManager.LoadScene(ValueShortcut.SceneName_Game);
    }

    public void SelectGameLevel() {
        MainMenu.SetActive(false);
        LevelSelection.SetActive(true);
    }

    public void SelectLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void BacktoMain() {
        MainMenu.SetActive(true);
        LevelSelection.SetActive(false);
    }

    public void QuitGame()
    {
       Application.Quit();
    }
}
