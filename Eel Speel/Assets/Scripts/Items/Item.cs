using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

	private void OnTriggerEnter(Collider other)
	{
		Debug.Log(other.tag);
		if (other.tag == "PlayerHead")
		{
			var shoot = other.transform.GetComponent<PlayerShoot>();
			shoot.Charge();

			StartCoroutine(Denable());
		}
	}

	private IEnumerator Denable()
	{
		var collider = GetComponentInChildren<Collider>();
		var renderer = GetComponentInChildren<Renderer>();

		collider.enabled = renderer.enabled = false;
		yield return new WaitForSeconds(5);
		collider.enabled = renderer.enabled = true;
	}
}
