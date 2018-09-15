using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

class CopyView
{
    private GameObject view = null;
    private Button exitBtn = null;

    public void Open()
    {
        if (view == null)
        {
            Object obj = Resources.Load("res/ui/CopyView");
            view = GameObject.Instantiate(obj) as GameObject;
            view.transform.SetParent(Main.UILayerMiddle.transform);
            //view.transform.localPosition = Vector2.zero;
            //view.transform..
            RectTransform rectCom = view.GetComponent<RectTransform>();
            rectCom.offsetMax = Vector2.zero;
            rectCom.offsetMin = Vector2.zero;
            //rectCom.
            //rectCom.sizeDelta = Vector2.zero;


            exitBtn = CommonFunc.FindObjects("exit")[0].GetComponent<Button>();
            exitBtn.onClick.AddListener(() =>
            {
                SetActive(false);

                SceneControl.Inst().ExitCurScene();
            });
        }
        SetActive(true);
    }

    public void SetActive(bool active)
    {
        view.SetActive(active);
    }

}
