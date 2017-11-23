using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuFacade : MonoBehaviour {

    public void ChangeScene(string nameNextScene)
    {
		SceneManager.LoadScene(nameNextScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }  
}


