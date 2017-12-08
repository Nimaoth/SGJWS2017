using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

	[SerializeField]
	private float playerSpeed;

	[SerializeField]
	private float movementForce;

	[SerializeField]
	private int id;

	private Rigidbody playerRigid;
	private Controller controller;

	void Start()
	{
		playerRigid = GetComponent<Rigidbody>();
		controller = new Controller(id);
	}

	void Update()
	{
		float speed = playerSpeed;
		//if (lookingAtBuff)
		//{
		//	yield return new waitForSeconds(0.1);
		//	speed *= speedBuff;
		//}
		//#region player Movement
		//Vector3 force = new Vector3();
		//#endregion

		var l = controller.GetLeftStick();
		var force = new Vector3(l.x, l.y, 0) * movementForce;
		playerRigid.AddForce(force);
	}
}
