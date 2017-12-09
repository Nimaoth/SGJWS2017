using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJoin : MonoBehaviour {

	public int id;
	public bool joined = false;

	public GameObject text;

	private Controller controller;

	private void Start()
	{
		controller = new Controller(id);
	}

	// Update is called once per frame
	void Update() {
		Debug.Log(controller.GetXDown());
		if (controller.GetXDown())
		{
			joined = !joined;
			text.SetActive(joined);
		}
	}
}
