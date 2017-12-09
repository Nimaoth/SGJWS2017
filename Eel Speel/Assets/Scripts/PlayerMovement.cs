using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public Transform bodyTransform;
	private List<Transform> bodyParts;
	public float minDistanc = 1;
	public float bodyRotSpeed = 50;

	public Transform sensor;

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

		bodyParts = new List<Transform>();
		for (int i = 0; i < bodyTransform.childCount; i++)
		{
			bodyParts.Add(bodyTransform.GetChild(i));
		}
	}

	void FixedUpdate()
	{
		var l = controller.GetLeftStick();
		var force = new Vector4(l.x, l.y, 0, 0) * movementForce;

		var uiae = transform.localToWorldMatrix * force;
			playerRigid.AddForce(uiae.x, uiae.y, uiae.z);

		var rightstick = controller.GetRightStick();
		//sensor.Rotate(new Vector3(rightstick.y * Time.deltaTime * -rotateSpeed, rightstick.x * Time.fixedDeltaTime * rotateSpeed, 0));

		sensor.rotation = Quaternion.Euler(rightstick.y * -rotateSpeed, rightstick.x * rotateSpeed, 0);

	}

	private void LateUpdate()
	{
		for (int i = 0; i < bodyParts.Count; i++)
		{
			Transform t = bodyParts[i];
			Transform p = i == 0 ? transform : bodyParts[i - 1];

			var dir = t.position - p.position;
			dir.Normalize();
			dir *= minDistanc;

			t.position = p.position + dir;
		}
	}
}
