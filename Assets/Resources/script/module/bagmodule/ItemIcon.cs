using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class ItemIcon
{
    public GameObject view = null;
    private Image img = null;

    private string mSource;
    public string Source
    {
        set {
            mSource = value;
            Sprite sp = Resources.Load("res/img/" + mSource, typeof(Sprite)) as Sprite;
            img.sprite = sp;
        }
        get
        {
            return mSource;
        }
    }

    public ItemIcon(GameObject parent)
    {
        Object obj = Resources.Load("res/ui/ItemIcon");
        view = GameObject.Instantiate(obj) as GameObject;
        view.transform.SetParent(parent.transform);

        img = CommonFunc.FindObjects("icon", view)[0].GetComponent<Image>();
    }
}
