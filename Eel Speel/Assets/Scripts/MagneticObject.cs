using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticObject : MonoBehaviour
{

    [SerializeField]
    private int pol = 0; //0=neutral, -1= blue, 1=yellow 
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            var Object = other.transform.parent.parent.parent.GetComponent<FollowPath>();
            var Player = other.transform.parent.parent.GetComponent<PlayerMovement>();
            var attractionAmount = Player.blueYellowNone * pol * (-1);
            Object.Acceleration = attractionAmount;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            var Object = other.transform.parent.parent.parent.GetComponent<FollowPath>();
            Object.Acceleration = 0.0f;
        }
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
