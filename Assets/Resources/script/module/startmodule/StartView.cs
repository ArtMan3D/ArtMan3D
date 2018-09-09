using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartView : MonoBehaviour
{
    public string sceneName = "scene1";
    public Button startBtn;

	// Use this for initialization
	void Start () {
        startBtn.onClick.AddListener(()=>{
            OnStartGame(sceneName);
        });
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnStartGame(string sceneName)
    {
        gameObject.SetActive(false);

        // to do ...
        // 
        
        
        ShowScene(sceneName);
    }

    void ShowScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        Object masterObj = Resources.Load("res/character/master/master");
        GameObject master = GameObject.Instantiate(masterObj) as GameObject;
        master.transform.position = new Vector3(0.4f, 0.92f, 3.56f);
        Player.SetHero(master);
        Player.heroAnimator.CrossFade("idle", 0.1f);

        GameObject cameraParent = GameObject.Find("CamParent");
        cameraParent.transform.position = new Vector3(0.38f, 19.2f, -18.18f);

        ETCInput.SetCameraTargetOffset("JoystickView", cameraParent.transform.position - master.transform.position);
        ETCInput.SetCameraTarget("JoystickView", master);
        ETCInput.SetAxisDirectTransform("Horizontal", master);
        ETCInput.SetAxisDirectTransform("Vertical", master);

        Object cubeObj = Resources.Load("res/cube");
        GameObject cube = GameObject.Instantiate(cubeObj) as GameObject;
        cube.name = "cube";
        // cube.transform.position = master.transform.position;
        cube.transform.position = new Vector3(master.transform.position.x + 5, master.transform.position.y, master.transform.position.z);
        // CopyControl.Inst().OpenReproduceView();
    }

}
