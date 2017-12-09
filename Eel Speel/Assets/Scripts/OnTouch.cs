using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTouch : MonoBehaviour {

    public GameObject font;
    public Color deactivated;
    public Color activated;

    private bool entered = false;

	// Use this for initialization
	void Start () {
        if(font != null)
        font.GetComponent<Renderer>().material.SetColor("_Color", deactivated);
    }
	
	// Update is called once per frame
	void Update () {
        //if an object enters the collider change the color of the title
        
    }

    private void OnTriggerEnter(Collider other)
    {
        font.GetComponent<Renderer>().material.SetColor("_Color", activated);
        entered = true;
        StartCoroutine("active");
    }

    private void OnTriggerExit(Collider other)
    {
        font.GetComponent<Renderer>().material.SetColor("_Color", deactivated);
        entered = false;
    }
    IEnumerator active()
    {
        while(entered)
        {
            yield return new WaitForSeconds(Random.Range(1f, 5f));
            yield return StartCoroutine("flickering");
        }
    }
    IEnumerator flickering()
    {
        int num = Random.Range(1, 4);
        for (int i = 0; i < num; i++)
        {
            if (entered)
            {
                font.GetComponent<Renderer>().material.color = deactivated;
                yield return new WaitForSeconds(Random.Range(0.01f, 0.1f));
                font.GetComponent<Renderer>().material.color = activated;
                yield return new WaitForSeconds(Random.Range(0.05f, 0.1f));
            }

        }
    }
}
