using UnityEngine;

public class MagneticObject : MonoBehaviour
{

	private void OnTriggerEnter(Collider other)
	{
		var Object = other.transform.parent.parent.parent.GetComponent<FollowPath>();
		if (other.tag == "Player" && other.transform.parent.parent.GetComponent<PlayerMovement>() == true)
		{
			Object.isAccelerating = true;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		var Object = other.transform.parent.parent.parent.GetComponent<FollowPath>();
		if (other.tag == "Player")
		{
			Object.isAccelerating = false;
		}
	}
}
