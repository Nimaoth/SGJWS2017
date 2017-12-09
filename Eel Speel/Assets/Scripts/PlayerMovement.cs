using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField]
	private float movementForce;

	[SerializeField]
	private float rotateSpeed;

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
		var l = controller.GetLeftStick();
		var force = new Vector4(l.x, l.y, 0, 0) * movementForce;

		var uiae = transform.localToWorldMatrix * force;
			playerRigid.AddForce(uiae.x, uiae.y, uiae.z);

		var rightStick = controller.GetRightStick();
		transform.Rotate(new Vector3(rightStick.y * Time.deltaTime * -rotateSpeed, rightStick.x * Time.fixedDeltaTime * rotateSpeed, 0));
		
	}
	
}
