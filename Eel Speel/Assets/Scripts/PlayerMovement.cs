using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float blueYellowNone = 0;
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

    [SerializeField]
    private float mindistance; //for SnakeLike player movement

    public List<Transform> BodyParts = new List<Transform>();
    private Rigidbody playerRigid;
	private Controller controller;

	private Vector3 previosPos = Vector3.zero;

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
        blueYellowNone = controller.GetBack2Axis();
		previosPos = transform.position;

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
		transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, 0);
        //transform.localPosition = Vector3.ClampMagnitude(transform.localPosition, maxLength);

		var prev = previosPos;
		for (int i = 0; i < bodyParts.Count; i++)
		{
			Transform t = bodyParts[i];
			Transform p = i == 0 ? transform : bodyParts[i - 1];

			//var q = t.position - p.position;
			//var d = (prev - t.position).normalized;
			//var b = 2.0f * Vector3.Dot(d, q);
			//var c = Vector3.Dot(q, q) - minDistanc * minDistanc;
			//var disc = b * b - 4 * c;

			//if (disc <= 0)
			{
				var dir = t.position - p.position;
				dir.Normalize();
				dir *= minDistanc;

				prev = t.position;
				t.position = p.position + dir;
			}
			//else
			//{
			//	prev = t.position;
			//	var f = -0.5f * (b + Mathf.Sqrt(disc));
			//	t.position += d * f;

			//	var dir = t.position - p.position;
			//	dir.Normalize();
			//	dir *= minDistanc;

			//	prev = t.position;
			//	t.position = p.position + dir;
			//}
		}

	}
}
