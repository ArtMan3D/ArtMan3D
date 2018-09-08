using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
public class CommonFunc
{
    public static List<GameObject> FindObjects(string childName, GameObject parent = null)
    {
        List<GameObject> retObjs = new List<GameObject>();
        if (parent != null)
        {
            Transform[] grandFa = parent.GetComponentsInChildren<Transform>();

            foreach (Transform child in grandFa)
            {
                if (child.name == childName)
                {
                    retObjs.Add(child.gameObject);
                }
            }
        }
        else
        {
            GameObject go = GameObject.Find(childName);
            if (go != null)
            {
                retObjs.Add(go);
            }
        }
        
        return retObjs;
    }
}
