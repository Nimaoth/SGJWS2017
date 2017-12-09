using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool blue = true;
    [SerializeField]
    private float maxLength;

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

		var targetRot = Quaternion.Euler(rightstick.y * -rotateSpeed, rightstick.x * rotateSpeed, 0);
		sensor.localRotation = Quaternion.Lerp(sensor.localRotation, targetRot, Time.fixedDeltaTime * 5);
        
	}

	private void LateUpdate()
	{
        transform.localPosition = Vector3.ClampMagnitude(transform.localPosition, maxLength);
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
