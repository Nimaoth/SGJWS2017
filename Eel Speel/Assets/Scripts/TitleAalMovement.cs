using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleAalMovement : MonoBehaviour {

    public GameObject anchor;
    public float maxlength;
    public GameObject rotationObject;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per 
	void Update () {
        Vector2 updated = new Vector2(transform.position.x + Input.GetAxis("HorizontalLeft_1") - anchor.transform.position.x, transform.position.y + Input.GetAxis("VerticalLeft_1") - anchor.transform.position.y);
        if(updated.magnitude > maxlength)
        {
            updated.Normalize();
            updated *= maxlength;
        }
     
        transform.position = new Vector3(Mathf.Clamp(updated.x + anchor.transform.position.x, -500, 500),Mathf.Clamp(updated.y + anchor.transform.position.y, -maxlength, 270), transform.position.z);

        
    }

    private void FixedUpdate()
    {
        //Vector3 ray = new Vector3(transform.position.x - rotationObject.transform.position.x, transform.position.y - rotationObject.transform.position.y, transform.position.z - rotationObject.transform.position.z);
        //Vector3 upRay = new Vector3(transform.position.x, 183 - transform.position.y, transform.position.z);
        //float alpha = Mathf.Abs(Vector3.Dot(upRay, ray) / (upRay.magnitude * ray.magnitude));
        //Debug.Log(alpha);
        //transform.RotateAround(new Vector3(191, 183), Vector3.forward, 90 - alpha);
        transform.LookAt(rotationObject.transform);
        transform.Rotate(Vector3.right, 90);
    }
}
