using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class BagView
{
    public GameObject view = null;
    private Button exitBtn = null;
    private GameObject content = null;
    private List<ItemIcon> iconList = new List<ItemIcon>();

    public void Open()
    {
        if (view == null)
        {
            Object obj = Resources.Load("res/ui/BagView");
            view = GameObject.Instantiate(obj) as GameObject;
            view.transform.SetParent(Main.UILayerMiddle.transform);
            RectTransform rectCom = view.GetComponent<RectTransform>();
            rectCom.offsetMax = Vector2.zero;
            rectCom.offsetMin = Vector2.zero;

            content = CommonFunc.FindObjects("Content", view)[0];

            exitBtn = CommonFunc.FindObjects("close")[0].GetComponent<Button>();
            exitBtn.onClick.AddListener(() =>
            {
                SetActive(false);
            });
        }
        SetActive(true);

        foreach(int itemID in BagModule.bagList)
        {
            OnBagInfoChange(itemID);
        }
    }

    private void OnBagInfoChange(int itemID)
    {
        ItemIcon icon = new ItemIcon(content);
        icon.Source = "Fizz_R";
        iconList.Add(icon);
    }

    public void SetActive(bool active)
    {
        view.SetActive(active);

        if (active)
        {
            BagModule.OnBagInfoChange += new BagModule.BagInfoChangeDelegate(OnBagInfoChange);
        }
        else
        {
            foreach (ItemIcon icon in iconList)
            {
                GameObject.Destroy(icon.view);
            }
            iconList.Clear();
            BagModule.OnBagInfoChange -= new BagModule.BagInfoChangeDelegate(OnBagInfoChange);
        }
    }

}
