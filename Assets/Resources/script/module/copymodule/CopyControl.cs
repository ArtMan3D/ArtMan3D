using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CopyControl : Singleton<CopyControl>
{
    private CopyView copyView = null;
    private ScrollUI scrollUI = null;
    private ReproduceView reproduceView = null;
    public CopyControl()
    {
        copyView = new CopyView();
        scrollUI = new ScrollUI();
        reproduceView = new ReproduceView();

        SceneControl.Inst().OnSceneExit += new SceneControl.SceneExiteDelegate(OnSceneExit);
        SceneControl.Inst().OnSceneEnter += new SceneControl.SceneEnterDelegate(OnSceneEnter);
    }

    public void OpenReproduceView()
    {
        reproduceView.Open();
    }

    public void OpenCopyView()
    {
        copyView.Open();
    }

    public void OpenScrollView()
    {
        scrollUI.Open();
    }

    private void OnSceneExit()
    {
        if (reproduceView.view != null)
        {
            reproduceView.SetActive(false);
        }
        if (scrollUI.view != null)
        {
            scrollUI.SetActive(false);
        }
        if (copyView.view != null)
        {
            copyView.SetActive(false);
        }
    }

    private void OnSceneEnter()
    {
        OpenCopyView();
    }

}
