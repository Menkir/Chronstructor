using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class utility : MonoBehaviour {

    public bool enab = false;
    /*
     Enable or disable visibility for explode, play and rotate button
         */
	public void switch_visiblity()
    {
        enab = !enab;
    }
}
