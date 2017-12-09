using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectionManager : MonoBehaviour {

	public static int[] PlayerIds = new int[] { 1,2,3 };

	public PlayerJoin[] players;
	
	// Update is called once per frame
	void Update () {
		if (Controller.GetPadDown())
		{
			PlayerIds = players.Where(p => p.joined).Select(p => p.id).ToArray();
			if (PlayerIds.Length >= 1)
			{
				SceneManager.LoadScene("movement");
			}
		}
	}
}
