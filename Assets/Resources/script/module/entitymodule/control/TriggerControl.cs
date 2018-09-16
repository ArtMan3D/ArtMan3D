using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // 开始接触
    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("开始接触 OnTriggerEnter : " + collision.gameObject.name);
    }

    // 接触结束
    void OnTriggerExit(Collider collision)
    {
        Debug.Log("接触结束 OnTriggerExit : " + collision.gameObject.name);
    }

    // 接触持续中
    void OnTriggerStay(Collider collision)
    {
        Debug.Log("接触持续中 OnTriggerStay : " + collision.gameObject.name);
    }


    // 碰撞开始
    void OnCollisionEnter(Collision collision) {
        Debug.Log("1开始接触 OnCollisionEnter : " + collision.gameObject.name);

    }

    // 碰撞结束
    void OnCollisionExit(Collision collision) {
        Debug.Log("1接触结束 OnCollisionExit : " + collision.gameObject.name);
    }

    // 碰撞持续中
    void OnCollisionStay(Collision collision) {
        Debug.Log("1接触持续中 OnCollisionStay : " + collision.gameObject.name);

    }

    // charactercontrol
    void OnControllerColliderHit (ControllerColliderHit hit) {
        Debug.Log("OnControllerColliderHit : " + hit.gameObject.name);
      if (hit.gameObject.name == "cube")
      {
      	hit.gameObject.SetActive(false);
      	//CopyControl.Inst().OpenReproduceView();
        BagModule.AddItem(1);
      }
 }

}
