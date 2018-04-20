using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class visibility : MonoBehaviour {

    public utility util;
	
	// Update is called once per frame
	void Update () {
        if (util.enab)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            gameObject.GetComponent<BoxCollider>().enabled = true;
        }
        else
        {

            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
