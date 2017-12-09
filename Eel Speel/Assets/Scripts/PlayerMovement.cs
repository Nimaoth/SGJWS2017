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

    [SerializeField]
    private float mindistance; //for SnakeLike player movement

    public List<Transform> BodyParts = new List<Transform>();
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
		var force = new Vector4(l.x, l.y, controller.GetR1() ? 1 : 0, 0) * movementForce;

		var uiae = transform.localToWorldMatrix * force;
		playerRigid.AddForce(uiae.x, uiae.y, uiae.z);

		var rightStick = controller.GetRightStick();
		transform.Rotate(new Vector3(rightStick.y * Time.deltaTime * 50, rightStick.x * Time.fixedDeltaTime * -50, 0));
	}
	
}
