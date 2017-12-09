using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SplitScreenMan : MonoBehaviour {

	// Use this for initialization
	void Start () {
		var ps = new List<GameObject>();
		for (int i = 0; i < transform.childCount; i++)
		{
			var p = transform.GetChild(i).gameObject;
			if (SelectionManager.PlayerIds.Contains(p.GetComponentInChildren<PlayerMovement>().id))
			{
				p.SetActive(true);
				ps.Add(p);
			}
		}
		
		switch (ps.Count)
		{
			case 2:
				{
					var cam1 = ps[0].GetComponentInChildren<Camera>();
					var cam2 = ps[1].GetComponentInChildren<Camera>();
					cam1.rect = new Rect(0, 0.5f, 1, 0.5f);
					cam2.rect = new Rect(0, 0, 1, 0.5f);
					break;
				}
			case 3:
				{
					var cam1 = ps[0].GetComponentInChildren<Camera>();
					var cam2 = ps[1].GetComponentInChildren<Camera>();
					var cam3 = ps[2].GetComponentInChildren<Camera>();
					cam1.rect = new Rect(0, 0.5f, 1, 0.5f);
					cam2.rect = new Rect(0, 0, 0.5f, 0.5f);
					cam3.rect = new Rect(0.5f, 0, 0.5f, 0.5f);
					break;
				}
			case 4:
				{
					var cam1 = ps[0].GetComponentInChildren<Camera>();
					var cam2 = ps[1].GetComponentInChildren<Camera>();
					var cam3 = ps[2].GetComponentInChildren<Camera>();
					var cam4 = ps[3].GetComponentInChildren<Camera>();
					cam1.rect = new Rect(0, 0.5f, 0.5f, 0.5f);
					cam2.rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
					cam3.rect = new Rect(0, 0, 0.5f, 0.5f);
					cam4.rect = new Rect(0.5f, 0, 0.5f, 0.5f);
					break;
				}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
