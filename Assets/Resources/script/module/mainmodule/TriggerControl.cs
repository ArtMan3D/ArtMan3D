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
    void OnTriggerEnter(Collider collider) {
        Debug.Log("开始接触");
    }

    // 接触结束
    void OnTriggerExit(Collider collider) {
        Debug.Log("接触结束");
    }

    // 接触持续中
    void OnTriggerStay(Collider collider) {
        Debug.Log("接触持续中");
    }


    // 碰撞开始
    void OnCollisionEnter(Collision collision) {
        // 销毁当前游戏物体
        // Destroy(this.gameObject);
        Debug.Log("1开始接触");

    }

    // 碰撞结束
    void OnCollisionExit(Collision collision) {
Debug.Log("1接触结束");
    }

    // 碰撞持续中
    void OnCollisionStay(Collision collision) {
Debug.Log("1接触持续中"+ collision.gameObject.name + "obj:" + gameObject.name);

    }

    void OnControllerColliderHit (ControllerColliderHit hit) { 
      //Debug.Log("RecieveMessage"+ hit.gameObject.name);
      if (hit.gameObject.name == "cube")
      {
      	hit.gameObject.SetActive(false);
      	CopyControl.Inst().OpenReproduceView();
      }
 }

}
