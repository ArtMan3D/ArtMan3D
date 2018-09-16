using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class BagControl : Singleton<BagControl>
{
    private BagView bagView = null;
    public BagControl()
    {
        bagView = new BagView();

        SceneControl.Inst().OnSceneExit += new SceneControl.SceneExiteDelegate(OnSceneExit);
    }
    private void OnSceneExit()
    {
        if (bagView.view != null)
        {
            bagView.SetActive(false);
        }
        BagModule.bagList.Clear();
    }

    public void OpenBagView()
    {
        bagView.Open();
    }
}
