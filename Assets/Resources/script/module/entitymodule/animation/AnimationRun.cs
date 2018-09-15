using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class AnimationRun : AnimationBase
{
    public enum Direct
    {
        none = -1,
        down,
        left,
        right,
        up
    }
    private string curAnimName = "";

    public AnimationRun(AnimationControl animControl, int id)
        : base(animControl, id)
    {
    }

    public override void DoBeforeEntering() 
    {
        mAnimControl.CrossFade(curAnimName, 0);
    }

    public override void DoBeforeLeaving() 
    {
    }

    public void SetRunDir(Direct dir)
    {
        if (dir == Direct.right)
        {
            curAnimName = "right";
        }
        else if (dir == Direct.left)
        {
            curAnimName = "left";
        }
        else if (dir == Direct.down)
        {
            curAnimName = "down";
        }
        else if (dir == Direct.up)
        {
            curAnimName = "up";
        }
    }

    public override void Do()
    {

    }
}
