using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour {

    public Button newGame;
    public Button endGame;

    public Text highscore;
    public Text message;



	// Use this for initialization
	void Start () {
        string name = Winner.names[0];
        message.text = "Herzlichen Glückwunsch, " + name + "!\nDu hast deine Konkurrenz besiegt.\nWie wäre es mit einem Rematch?";
        newGame.onClick.AddListener(LoadGame);
        endGame.onClick.AddListener(LoadMenu);
        for (int i = 0; i < Winner.players.Count; i++)
        {
            Debug.Log("Winner.names.count: " + Winner.names.Count);
            Debug.Log("i: " + i);
            Debug.Log(Winner.names[i]);
            highscore.text += (i+1) + ". Platz: " + Winner.names[i] + "\n";
        }
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
