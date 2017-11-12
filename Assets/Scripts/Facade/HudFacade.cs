using UnityEngine;
using UnityEngine.SceneManagement;

public class HudFacade
{
    ChangeScene _changeScene;

    public HudFacade(string nameMenu)
    {
        _changeScene = new ChangeScene();
    }
  
    public void SetNextScene(string nameNextScene)
    {
        _changeScene.SetNextScene(nameNextScene);
    }
}
