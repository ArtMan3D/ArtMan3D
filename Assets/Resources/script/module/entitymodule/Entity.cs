using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Entity : System.IDisposable
{
    protected GameObject gameObject = null;
    private float speed = 1;
    public Entity()
    {

    }

    public void InitEntityView(string res)
    {
        Object masterObj = Resources.Load("res/" + res);
        gameObject = GameObject.Instantiate(masterObj) as GameObject;
    }

    public GameObject GetGameObject()
    {
        return gameObject;
    }

    public void SetSpeed(float sp)
    {
        speed = sp;
    }
    public float GetSpeed()
    {
        return speed;
    }

    public virtual void Dispose()
    {
        if (gameObject != null)
        {
            GameObject.Destroy(gameObject);
            gameObject = null;
        }
    }
}
