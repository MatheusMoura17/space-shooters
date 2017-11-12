using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCtrl : MonoBehaviour {

    HudFacade hud = new HudFacade("MainMenu");

    public void ChangeScene(string nameNextScene)
    {
        hud.SetNextScene(nameNextScene);
    }
}
