using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {

    public static GameObject UILayerMain = null;
    public static GameObject UILayerMiddle = null;
    public static GameObject UILayerTop = null;
    public static ETCJoystick JoystickCom = null;
    public static Hero Hero;

    void Awake()
    {
        UILayerMain = CommonFunc.FindObjects("mainlayer")[0];
        UILayerMiddle = CommonFunc.FindObjects("middlelayer")[0];
        UILayerTop = CommonFunc.FindObjects("toplayer")[0];
        JoystickCom = CommonFunc.FindObjects("JoystickView")[0].GetComponent<ETCJoystick>();

        CopyControl.Inst();
        BagControl.Inst();
    }

    public static void SetHero(Hero he)
    {
        Hero = he;
    }

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
