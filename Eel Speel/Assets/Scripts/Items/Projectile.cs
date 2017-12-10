using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	public GameObject lightningPrefab;
	public int count;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < count; i++)
		{
			Instantiate(lightningPrefab, Vector3.zero, Quaternion.identity, transform);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
