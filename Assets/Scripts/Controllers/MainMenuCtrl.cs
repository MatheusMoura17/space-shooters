using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCtrl : MonoBehaviour {

    private HudFacade hud;
    
    public void ChangeScene(string nameNextScene)
    {
        hud.SetNextScene(nameNextScene);
    }
}
