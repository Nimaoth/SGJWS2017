using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour {

    public Button newGame;
    public Button endGame;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        newGame.onClick.AddListener(LoadGame);
        endGame.onClick.AddListener(LoadMenu);
	}

    void LoadGame() {
        SceneManager.LoadScene("player_seletion");
    }

    void LoadMenu() {
        SceneManager.LoadScene("menu");
    }
}
