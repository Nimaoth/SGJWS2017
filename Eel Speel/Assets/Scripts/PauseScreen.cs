using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScreen : MonoBehaviour {

    private bool frozen = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!frozen && (Input.GetKeyDown("joystick 1 button 9") || Input.GetKeyDown("joystick 2 button 9") 
            || Input.GetKeyDown("joystick 3 button 9") || Input.GetKeyDown("joystick 4 button 9")))
        {
            Time.timeScale = 0;
            //enable text and use darker canvas over scene

            frozen = true;
        }

        if (frozen && (Input.GetKeyDown("joystick 1 button 2") || Input.GetKeyDown("joystick 2 button 2")
            || Input.GetKeyDown("joystick 3 button 2") || Input.GetKeyDown("joystick 4 button 2")))
        {
            Time.timeScale = 1;
            frozen = false;
        }
	}


}
