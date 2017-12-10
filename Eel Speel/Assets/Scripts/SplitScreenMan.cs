using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SplitScreenMan : MonoBehaviour {

    public static List<FollowPath> players = new List<FollowPath>();

	// Use this for initialization
	void Start () {
		for (int i = 0; i < transform.childCount; i++)
		{
			var p = transform.GetChild(i).gameObject;
			if (SelectionManager.PlayerIds.Contains(p.GetComponentInChildren<PlayerMovement>().id))
			{
				p.SetActive(true);
				players.Add(p.GetComponentInChildren<FollowPath>());
				players[i].totalDistance = 0.1f * (4 - i);
			}
		}
		
		switch (players.Count)
		{
			case 2:
				{
					var cam1 = players[0].transform.parent.GetComponentInChildren<Camera>();
					var cam2 = players[1].transform.parent.GetComponentInChildren<Camera>();
					cam1.rect = new Rect(0, 0.5f, 1, 0.5f);
					cam2.rect = new Rect(0, 0, 1, 0.5f);
					break;
				}
			case 3:
				{
					var cam1 = players[0].transform.parent.GetComponentInChildren<Camera>();
					var cam2 = players[1].transform.parent.GetComponentInChildren<Camera>();
					var cam3 = players[2].transform.parent.GetComponentInChildren<Camera>();
					cam1.rect = new Rect(0, 0.5f, 1, 0.5f);
					cam2.rect = new Rect(0, 0, 0.5f, 0.5f);
					cam3.rect = new Rect(0.5f, 0, 0.5f, 0.5f);
					break;
				}
			case 4:
				{
					var cam1 = players[0].transform.parent.GetComponentInChildren<Camera>();
					var cam2 = players[1].transform.parent.GetComponentInChildren<Camera>();
					var cam3 = players[2].transform.parent.GetComponentInChildren<Camera>();
					var cam4 = players[3].transform.parent.GetComponentInChildren<Camera>();
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
        players.Sort((p1, p2) => (int)Mathf.Sign(p2.totalDistance - p1.totalDistance));
	}
}
