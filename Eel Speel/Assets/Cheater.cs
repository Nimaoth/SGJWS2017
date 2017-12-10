using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cheater : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.F1))
			SceneManager.LoadScene("menu");

		else if (Input.GetKeyDown(KeyCode.F2))
			SceneManager.LoadScene("player_seletion");

		else if (Input.GetKeyDown(KeyCode.F3))
			SceneManager.LoadScene("movement");

		else if (Input.GetKeyDown(KeyCode.F4))
			SceneManager.LoadScene("EndScreen");

		else if (Input.GetKeyDown(KeyCode.F5))
			SceneManager.LoadScene("tutorial");
	}
}
