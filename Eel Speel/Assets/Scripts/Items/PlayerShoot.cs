﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

	public int maxCharge = 3;

	[SerializeField]
	private int charge = 0;

	private Controller controller;

	public GameObject projectile;
	public Transform projectileOrientation;

	public LayerMask mask;

	void Start () {
		int id = GetComponent<PlayerMovement>().id;
		controller = new Controller(id);
	}
	
	void Update () {
		if (controller.GetR1Down() && charge > 0)
		{
			charge--;
			
			var v = Instantiate(projectile, transform.position, projectileOrientation.rotation);
			v.GetComponent<Projectile>().mask = mask;
		}
	}

	public void Charge()
	{
		charge++;
		if (charge > maxCharge)
		{
			Overcharge();
		}
	}

	private void Overcharge()
	{
		charge = 0;
		// TODO: spawn explosion


	}
}
