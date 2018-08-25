using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMeniu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnStartGame(string sceneName)
    {
        Application.LoadLevel(sceneName);
    }

    public void OnCloseGame()
    {
        Application.Quit();
    }

}
