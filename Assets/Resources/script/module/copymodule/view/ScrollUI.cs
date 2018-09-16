using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class ScrollUI
{
    public GameObject view = null;
    private Button exitBtn = null;

    public void Open()
    {
        if (view == null)
        {
            Object obj = Resources.Load("res/ui/ScrollView");
            view = GameObject.Instantiate(obj) as GameObject;
            view.transform.SetParent(Main.UILayerMiddle.transform);
            RectTransform rectCom = view.GetComponent<RectTransform>();
            rectCom.anchoredPosition = new Vector2(0, 64);


            exitBtn = CommonFunc.FindObjects("close")[0].GetComponent<Button>();
            exitBtn.onClick.AddListener(() =>
            {
                SetActive(false);
            });
        }
        SetActive(true);
    }

    public void SetActive(bool active)
    {
        view.SetActive(active);
    }

}
