using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class SceneControl : Singleton<SceneControl>
{
    public SceneIns curScene = null;
    public delegate void SceneExiteDelegate();
    public SceneExiteDelegate OnSceneExit;
    public delegate void SceneEnterDelegate();
    public SceneEnterDelegate OnSceneEnter;

    public SceneControl()
    {

    }

    public void ChangeScene(string sceneName)
    {
        CleanCurScene();

        Resources.UnloadUnusedAssets();

        if (OnSceneEnter != null)
        {
            OnSceneEnter.Invoke();
        }

        curScene = new SceneIns(sceneName);
    }

    public void ExitCurScene()
    {
        if (OnSceneExit != null)
        {
            OnSceneExit.Invoke();
        }
        CleanCurScene();

        Resources.UnloadUnusedAssets();
    }

    public void CleanCurScene()
    {
        if (curScene != null)
        {
            curScene.Dispose();
            curScene = null;
        }
    }
}
