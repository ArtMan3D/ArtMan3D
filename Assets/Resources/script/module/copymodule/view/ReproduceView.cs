using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReproduceView
{
    private GameObject view = null;
    private Button closeBtn = null;

    public void Open()
    {
        Object obj = Resources.Load("res/ui/ReproduceView");
        view = GameObject.Instantiate(obj) as GameObject;
        view.transform.SetParent(Main.UILayerMiddle.transform);
        view.transform.localPosition = Vector2.zero;

        List<GameObject> cutAreaImgList = new List<GameObject>();
        for(int i = 0; i < 3; i++)
        {
            GameObject cutImg = CommonFunc.FindObjects("cutAreaImg" + (i + 1), view)[0];
            MoveDirection dirCom = cutImg.AddComponent<MoveDirection>();
            dirCom.OnDirChange = new MoveDirection.DirChange(OnDirChange);
            cutAreaImgList.Add(cutImg);
        }

        closeBtn = CommonFunc.FindObjects("close")[0].GetComponent<Button>();
        closeBtn.onClick.AddListener(() =>
        {
            SetActive(false);
        });
        closeBtn.gameObject.SetActive(false);
    }

    public void SetActive(bool active)
    {
        view.SetActive(active);
    }

    public void OnDirChange(GameObject go, SlideVector dir)
    {
        if (dir == SlideVector.down)
        {
            go.SetActive(false);
            closeBtn.gameObject.SetActive(true);
        }
    }
}
