using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Hero : Entity
{
    private GameObject cameraParent;
    private JoyMoveControl joyMoveControl;
    public AnimationControl animationControl;
    
    public Hero()
    {
        InitEntityView("character/master/master");
        gameObject.transform.position = new Vector3(0.4f, 0.92f, 3.56f);
        gameObject.AddComponent<TriggerControl>();

        Main.SetHero(this);

        InitCamera();
        InitJoystick();
        InitJoyMoveControl();
        InitAnimationControl();
    }

    void InitCamera()
    {
        cameraParent = GameObject.Find("CamParent");
        cameraParent.transform.position = new Vector3(0.38f, 19.2f, -18.18f);
    }

    void InitJoystick()
    {
        Main.JoystickCom.followOffset = cameraParent.transform.position - gameObject.transform.position;
        Main.JoystickCom.cameraLookAt = gameObject.transform;
        Main.JoystickCom.axisX.directTransform = gameObject.transform;
        Main.JoystickCom.axisY.directTransform = gameObject.transform;
    }

    void InitJoyMoveControl()
    {
        joyMoveControl = new JoyMoveControl(this);
    }

    void InitAnimationControl()
    {
        animationControl = new AnimationControl(this);
        animationControl.SetAnimationState(AnimationState.Animation.Idle);
    }

    public override void Dispose()
    {
        joyMoveControl.Dispose();
        Main.SetHero(null);
        base.Dispose();
    }
}
