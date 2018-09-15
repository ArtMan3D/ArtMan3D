using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

        SceneControl.Inst().OnSceneExit += new SceneControl.SceneExiteDelegate(OnSceneExit);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnStartGame(string sceneName)
    {
        gameObject.SetActive(false);

        // to do ...
        // 

        SceneControl.Inst().ChangeScene(sceneName);

        CopyControl.Inst().OpenCopyView();
    }

    public void OnSceneExit()
    {
        gameObject.SetActive(true);
    }
}
