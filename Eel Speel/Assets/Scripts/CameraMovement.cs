using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	[SerializeField]
	private Transform player;
	
	// Update is called once per frame
	void Update () {
		var targetPosition = player.forward * -10;

		var dir = Quaternion.LookRotation(player.position - transform.position);	// target rotation
		dir = Quaternion.Lerp(transform.rotation, dir, Time.deltaTime);				// move smoothly between current rotation and target rotation
		transform.rotation = dir;													// store calculated rotation in transform
	}
}
