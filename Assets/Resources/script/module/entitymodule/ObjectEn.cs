using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class ObjectEn : Entity
{
    public ObjectEn()
    {
        InitEntityView("cube");

        gameObject.name = "cube";
        gameObject.transform.position = new Vector3(
            Main.Hero.GetGameObject().transform.position.x + 5,
            Main.Hero.GetGameObject().transform.position.y,
            Main.Hero.GetGameObject().transform.position.z
        );
    }
}
