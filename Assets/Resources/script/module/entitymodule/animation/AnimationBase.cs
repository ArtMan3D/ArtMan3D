using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class AnimationBase : FSMState
{
    protected AnimationControl mAnimControl;
    public AnimationBase(AnimationControl animControl, int id):base(id)
    {
        mAnimControl = animControl;
    }

    public bool CanChangeState()
    {
        return true;
    }
}
