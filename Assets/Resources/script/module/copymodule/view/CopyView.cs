using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

class CopyView
{
    public GameObject view = null;
    private Button exitBtn = null;

    public void Open()
    {
        if (view == null)
        {
            Object obj = Resources.Load("res/ui/CopyView");
            view = GameObject.Instantiate(obj) as GameObject;
            view.transform.SetParent(Main.UILayerMiddle.transform);
            RectTransform rectCom = view.GetComponent<RectTransform>();
            rectCom.offsetMax = Vector2.zero;
            rectCom.offsetMin = Vector2.zero;

            InitEvent();
        }
        SetActive(true);
    }

    void InitEvent()
    {
        exitBtn = CommonFunc.FindObjects("exit")[0].GetComponent<Button>();
        exitBtn.onClick.AddListener(() =>
        {
            SetActive(false);

            SceneControl.Inst().ExitCurScene();
        });

        Button bagBtn = CommonFunc.FindObjects("bagBtn")[0].GetComponent<Button>();
        bagBtn.onClick.AddListener(() =>
        {
            BagControl.Inst().OpenBagView();
        });

        Button scrollBtn = CommonFunc.FindObjects("scrollBtn")[0].GetComponent<Button>();
        scrollBtn.onClick.AddListener(() =>
        {
            CopyControl.Inst().OpenScrollView();
        });

        Button reproduceBtn = CommonFunc.FindObjects("reproduceBtn")[0].GetComponent<Button>();
        reproduceBtn.onClick.AddListener(() =>
        {
            CopyControl.Inst().OpenReproduceView();
        });

    }

    public void SetActive(bool active)
    {
        view.SetActive(active);
    }

}
