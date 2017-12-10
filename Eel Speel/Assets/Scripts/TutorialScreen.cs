using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if(Input.GetKeyDown("joystick 1 button 2") || Input.GetKeyDown("joystick 2 button 2") || Input.GetKeyDown("joystick 3 button 2") || Input.GetKeyDown("joystick 4 button 2"))
        {
            SceneManager.LoadScene("menu");
        }
	}
}
