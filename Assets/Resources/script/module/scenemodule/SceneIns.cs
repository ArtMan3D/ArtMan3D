using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.SceneManagement;

public class SceneIns : IDisposable
{
    private string mSceneName;
    private List<Entity> entityList = new List<Entity>();
    public SceneIns(string sceneName)
    {
        mSceneName = sceneName;
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);

        CreateEntity();
    }

    public void CreateEntity()
    {
        Hero hero = new Hero();
        ObjectEn obj = new ObjectEn();

        entityList.Add(hero);
        entityList.Add(obj);
    }

    public void Dispose()
    {
        foreach(Entity en in entityList)
        {
            en.Dispose();
        }
        entityList.Clear();

        SceneManager.UnloadSceneAsync(mSceneName);
    }
}
