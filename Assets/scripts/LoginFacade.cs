using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginFacade : MonoBehaviour {

	public InputField userNameInput;

    public void ChangeScene(string nameNextScene)
    {
		SceneManager.LoadScene(nameNextScene);
    }

	public void Login()
	{
		if (userNameInput.text != "" && userNameInput.text!=" ") {
			//checar login
		}
	}
}


