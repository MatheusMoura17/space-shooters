using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuFacade : MonoBehaviour {

    ChangeScene _changeScene;

    public void ChangeScene(string nameNextScene)
    {
        _changeScene.SetNextScene(nameNextScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    
}

public class ChangeScene
{
    public void SetNextScene(string nameNextScene)
    {
        SceneManager.LoadScene(nameNextScene);
    }
}



