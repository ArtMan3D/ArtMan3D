using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class AnimationIdle : AnimationBase
{
    private float preSpeed = 0;
    private float animOffset = 0;
    public AnimationIdle(AnimationControl animControl, int id)
        :base(animControl, id)
    {
    }
    public override void DoBeforeEntering()
    {
        preSpeed = mAnimControl.GetSpeed();

        mAnimControl.CrossFade("idle", 0, animOffset);
        mAnimControl.SetSpeed(0);
    }

    public override void DoBeforeLeaving()
    {
        mAnimControl.SetSpeed(preSpeed);
    }

    public void SetIdleTimeOffset(float offset)
    {
        animOffset = offset;
    }

    public override void Do()
    {

    }
}
