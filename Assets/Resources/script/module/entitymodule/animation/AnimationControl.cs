using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class AnimationControl
{
    private Entity mEntity;
    private GameObject gameObject;
    private Animator entityAnimator;
    private FSMSystem fsmSystem;

    public AnimationControl(Entity entity)
    {
        mEntity = entity;
        gameObject = mEntity.GetGameObject();

        entityAnimator = gameObject.GetComponent<Animator>();
        SetSpeed(mEntity.GetSpeed());

        InitAnimationState();
    }

    void InitAnimationState()
    {
        fsmSystem = new FSMSystem();
        fsmSystem.AddState(new AnimationIdle(this, (int)AnimationState.Animation.Idle));
        fsmSystem.AddState(new AnimationRun(this, (int)AnimationState.Animation.Run));
    }

    public void SetAnimationState(AnimationState.Animation state)
    {
        fsmSystem.ChangeState((int)state);
    }

    public void CrossFade(string stateName, float normalizedTransitionDuration, float normalizedTimeOffset = float.NegativeInfinity)
    {
        Debug.Log("crossfade:" +  stateName + "speed:" + entityAnimator.speed);

        entityAnimator.CrossFade(stateName, normalizedTransitionDuration, -1, normalizedTimeOffset);
    }

    public void SetIdleTimeOffset(float offset)
    {
        AnimationIdle Idle = (AnimationIdle)fsmSystem.GetState((int)AnimationState.Animation.Idle);
        Idle.SetIdleTimeOffset(offset);
    }

    public void SetRunDir(AnimationRun.Direct dir)
    {
        AnimationRun run = (AnimationRun)fsmSystem.GetState((int)AnimationState.Animation.Run);
        run.SetRunDir(dir);
    }

    public void SetSpeed(float speed)
    {
        entityAnimator.speed = speed;
    }

    public float GetSpeed()
    {
        return mEntity.GetSpeed();
    }
}
