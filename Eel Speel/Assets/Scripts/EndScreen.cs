using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour {

    public Button newGame;
    public Button endGame;

    public Text message;



	// Use this for initialization
	void Start () {
        string name = FollowPath.name;
        message.text = "Herzlichen Glückwunsch, " + name + "!\nDu hast deine Konkurrenz besiegt.\nWie wäre es mit einem Rematch?";
        newGame.onClick.AddListener(LoadGame);
        endGame.onClick.AddListener(LoadMenu);
    }
	
	// Update is called once per frame
	void Update () {
        
        
	}

    void LoadGame() {
        SceneManager.LoadScene("player_seletion");
    }

    void LoadMenu() {
        SceneManager.LoadScene("menu");
    }
}
