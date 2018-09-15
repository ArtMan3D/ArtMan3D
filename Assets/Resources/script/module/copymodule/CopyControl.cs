using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CopyControl : Singleton<CopyControl>
{
    private CopyView copyView = null;
    private ReproduceView reproduceView = null;

    public CopyControl()
    {
        copyView = new CopyView();

        reproduceView = new ReproduceView();

    }

    public void OpenReproduceView()
    {
        reproduceView.Open();
    }

    public void OpenCopyView()
    {
        copyView.Open();
    }

}
