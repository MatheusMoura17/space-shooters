using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginFacade : MonoBehaviour {

	public InputField userNameInput;

	void Start(){
		MusicManager.instance.PlayMusic (MusicManager.MusicNames.MENU);
	}

    public void ChangeScene(string nameNextScene)
    {
		SceneManager.LoadScene(nameNextScene);
    }

	public void Login()
	{
		if (userNameInput.text != "" && userNameInput.text!=" " && Network.instance.Connected) {
			Network.instance.Login (userNameInput.text);
			ChangeScene ("Game");
		}
	}
}


