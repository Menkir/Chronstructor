using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ElementStartAnimation : MonoBehaviour {

    public IEnumerator play(int i =1) {

        while (true)
        {
            play_animation("_rev");
            yield return new WaitForSeconds(i);
            play_animation();
            yield return new WaitForSeconds(i);
            play_animation("_rev");

        }

    }

    /*
     Wrapper method for play(). Otherwise we cannot catch null reference .
         */
    private void play_animation(string suffix="")
    {
        try
        {
            transform.GetComponent<Animator>().Play(gameObject.name + suffix);
        } catch (NullReferenceException e)
        {
            Debug.Log("You need to define " + gameObject.name+suffix + ".anim to work properly.");
        }
        
    }

	
}
