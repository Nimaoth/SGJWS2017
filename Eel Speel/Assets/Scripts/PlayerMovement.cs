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

	void FixedUpdate()
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
		var f = 0;
		if (controller.GetL1())
			f--;
		if (controller.GetR1())
			f++;
		var force = new Vector4(l.x, l.y, f * 1.0f, 0) * movementForce;

		var uiae = transform.localToWorldMatrix * force;
		playerRigid.AddForce(uiae.x, uiae.y, uiae.z);

		var rightStick = controller.GetRightStick();
		transform.Rotate(new Vector3(rightStick.y * Time.deltaTime * -50, rightStick.x * Time.fixedDeltaTime * 50, 0));
		
	}
	
}
