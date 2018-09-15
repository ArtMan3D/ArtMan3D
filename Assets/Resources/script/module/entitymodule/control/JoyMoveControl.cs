using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyMoveControl : System.IDisposable
{
    private AnimationRun.Direct mCurDir = AnimationRun.Direct.none;
    private Hero mHero;
    public JoyMoveControl(Hero hero)
    {
        mHero = hero;

        Main.JoystickCom.onMoveStart.AddListener(MoveBegin);
        Main.JoystickCom.onMove.AddListener(Move);
        Main.JoystickCom.onMoveEnd.AddListener(MoveEnd);
    }

	public void MoveBegin()
	{
        mCurDir = AnimationRun.Direct.none;
	}

	public void Move(Vector2 delta)
	{
        float speed = 0;
        if (Mathf.Abs(delta.x) >= Mathf.Abs(delta.y))
        {
            if (delta.x > 0)
            {
                mCurDir = AnimationRun.Direct.right;
            }
            else if (delta.x < 0)
            {
                mCurDir = AnimationRun.Direct.left;
            }
            speed = Mathf.Abs(delta.x) / 1;
        }
        else
        {
            if (delta.y < 0)
            {
                mCurDir = AnimationRun.Direct.down;
            }
            else if (delta.y > 0)
            {
                mCurDir = AnimationRun.Direct.up;
            }
            speed = Mathf.Abs(delta.y) / 1;
        }
        if (mCurDir != AnimationRun.Direct.none)
        {
            mHero.SetSpeed(speed);
            mHero.animationControl.SetSpeed(speed);
            mHero.animationControl.SetRunDir(mCurDir);
            mHero.animationControl.SetAnimationState(AnimationState.Animation.Run);
        }
	}

	public void MoveEnd()
	{
        mHero.SetSpeed(1);
        mHero.animationControl.SetSpeed(1);
        mHero.animationControl.SetIdleTimeOffset((float)mCurDir / 4.0f);
        mHero.animationControl.SetAnimationState(AnimationState.Animation.Idle);
        mCurDir = AnimationRun.Direct.none;
	}

    public void Dispose()
    {
        Main.JoystickCom.onMoveStart.RemoveListener(MoveBegin);
        Main.JoystickCom.onMove.RemoveListener(Move);
        Main.JoystickCom.onMoveEnd.RemoveListener(MoveEnd);
    }
}
