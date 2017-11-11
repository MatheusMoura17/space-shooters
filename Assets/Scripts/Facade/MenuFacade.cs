using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuFacade : MonoBehaviour {

    ChoseScene cm = new ChoseScene();
    QuitGame qg = new QuitGame();

    public void ChangeScene(string nameScene)
    {
        cm.SetNextScene(nameScene);
    }
}

public class ChoseScene
{
    string currentScene;

    public void SetNextScene(string nameNextScene)
    {
        SceneManager.LoadScene(nameNextScene);
    }
}

public class QuitGame
{
    public void ExitGame()
    {
        Application.Quit();
    }
}