using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticObject : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("not if");
        var Object = other.transform.parent.parent.parent.GetComponent<FollowPath>();
        if (other.tag == "Player" && other.transform.parent.parent.GetComponent<PlayerMovement>() == true)
        {
            Object.isAccelerating = true;
            Debug.Log("booost");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var Object = other.transform.parent.parent.parent.GetComponent<FollowPath>();
        if  (other.tag == "Player")
            {
                Object.isAccelerating = false;
            Debug.Log("boost end");
            }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
