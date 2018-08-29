using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUI : MonoBehaviour
{

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnStartGame(string sceneName)
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        Object masterObj = Resources.Load("res/character/master/master");
        GameObject master = Instantiate(masterObj) as GameObject;
        master.transform.position = new Vector3(0.4f, 0.92f, 3.56f);

        GameObject cameraParent = GameObject.Find("CamParent");
        cameraParent.transform.position = new Vector3(0.38f, 19.2f, -18.18f);

        ETCInput.SetCameraTargetOffset("JoystickView", cameraParent.transform.position - master.transform.position);
        ETCInput.SetCameraTarget("JoystickView", master);
        ETCInput.SetAxisDirectTransform("Horizontal", master);
        ETCInput.SetAxisDirectTransform("Vertical", master);

    }

}
