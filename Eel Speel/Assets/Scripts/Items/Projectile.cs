using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	public GameObject lightningPrefab;
	public int count;
	public LayerMask mask;

	// Use this for initialization
	void Start () {
		var ray = new Ray(transform.position, transform.forward);
		RaycastHit info;
		var dist = float.MaxValue;
		if (Physics.Raycast(ray, out info, float.MaxValue, mask))
		{
			dist = info.distance + 25;
			
			if (info.transform.tag == "PlayerAnchor")
			{
				info.transform.GetComponent<FollowPath>().multiplier *= 0.5f;
			}
		}

		for (int i = 0; i < count; i++)
		{
			var go = Instantiate(lightningPrefab, transform.position, transform.rotation);
			go.GetComponent<Lightning>().maxDist = dist;
		}

		Destroy(gameObject);
	}
}
