using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	[SerializeField]
	private Transform player;

	[SerializeField]
	private float moveSpeed;

	[SerializeField]
	private float smoothTime;

	[SerializeField]
	private float lookSpeed;


	private Vector3 velocity = Vector3.zero;

	// Update is called once per frame
	void FixedUpdate () {
		// position
		var targetPosition = player.position + player.forward * -10;
		transform.position = Vector3.Lerp(transform.position, targetPosition, Time.fixedDeltaTime * moveSpeed);

		// rotation
		var dir = Quaternion.LookRotation(player.position - transform.position);    // target rotation
		dir = Quaternion.Lerp(transform.rotation, dir, Time.fixedDeltaTime * lookSpeed);	// move smoothly between current rotation and target rotation
		transform.rotation = dir;                                                   // store calculated rotation in transform
	}
}
