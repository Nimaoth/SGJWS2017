using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	[SerializeField]
	private float playerSpeed;

	private Rigidbody playerRigid;

	void Start()
	{
		playerRigid = GetComponent<Rigidbody>();
	}

	void Update()
	{
		float speed = playerSpeed;
		if (lookingAtBuff)
		{
			yield return new waitForSeconds(0.1);
			speed *= speedBuff;
		}
		#region player Movement
		Vector3 force = new Vector3();
		#endregion
	}
}
