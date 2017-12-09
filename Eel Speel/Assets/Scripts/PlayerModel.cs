using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour {
   
   
    [SerializeField]
    private float speed;

    [SerializeField]
    private float rotationSpeed;

    public GameObject bodyprefab;

    private float dis;
    private Transform curBodyPart;
    private Transform prevBodyPart;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float curSpeed = 2;


	}
}
