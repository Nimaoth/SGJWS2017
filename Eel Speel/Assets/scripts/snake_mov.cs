using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snake_mov : MonoBehaviour {

    public float scrollSpeedX;
    public float scrollSpeedY;
    public Renderer rend;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerBody")
        {
            var Object = other.transform.parent.parent.parent.GetComponent<FollowPath>();
            Object.Acceleration = 0.0f;
            Debug.Log("snake hit");
        }
    }

    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
        float offsetX = Time.time * scrollSpeedX;
        float offsetY = Time.time * scrollSpeedY;
        rend.material.SetTextureOffset("_MainTex", new Vector2(offsetX, offsetY));
    }
}
