using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour {

    public Button startButton;
    public Button tutorialButton;

	// Use this for initialization
	void Start () {
        startButton.onClick.AddListener(LoadStartScene);
        tutorialButton.onClick.AddListener(LoadTutorial);
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    void LoadStartScene()
    {
        SceneManager.LoadScene("player_seletion");
    }

    void LoadTutorial()
    {
        SceneManager.LoadScene("tutorial");
    }
    
}
