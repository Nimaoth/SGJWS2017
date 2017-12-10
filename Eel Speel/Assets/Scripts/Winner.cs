using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Winner : MonoBehaviour {
    public static List<FollowPath> players = new List<FollowPath>();
    public static List<string> names = new List<string>();
    public int playerCount;

    [SerializeField]
    private float delayTime = 4.0f;

    public static void AddToList(FollowPath player)
    {
              players.Add(player);      
    }



	// Use this for initialization
	void Start () {
        playerCount = SplitScreenMan.players.Count;
    }
	
	// Update is called once per frame
	void Update () {
		if (players.Count == playerCount)
        {

            for (int i = 0; i < playerCount; i++)
            {
                switch (players[i].transform.GetComponentInChildren<PlayerMovement>().id)
                {
                    case 1:
                        names.Add("Aal Capone");
                        break;
                    case 2:
                        names.Add("Maalefitz");
                        break;
                    case 3:
                        names.Add("Sir Eelington");
                        break;
                    case 4:
                        names.Add("Senor Moreno");
                        break;
                    default:
                        break;
                };
            }
            Invoke("DelayedAction", delayTime);
        }
	}

    private void DelayedAction()
    {
        SceneManager.LoadScene("EndScreen");
    }
}
