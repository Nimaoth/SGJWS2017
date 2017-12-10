using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "PlayerHead")
		{
			var shoot = other.transform.GetComponent<PlayerShoot>();
			shoot.Charge();

			StartCoroutine(Denable());
		}
	}

	private IEnumerator Denable()
	{
		gameObject.SetActive(false);
		yield return new WaitForSeconds(5);
		gameObject.SetActive(true);
	}
}
