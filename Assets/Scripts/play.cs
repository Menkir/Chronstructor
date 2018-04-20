using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class play : MonoBehaviour {

    public Sprite pla, pause;
    private Sprite current;
    private string status;

    public void Start()
    {
        current = pause;
        status = "play";
    }

    public void switch_sprite()
    {
        if(current == pla)
        {
            current = pause;
            status = "play";
        } else
        {
            current = pla;
            status = "pause";
        }

        transform.GetComponent<SpriteRenderer>().sprite = current;
    }

    public string getStatus()
    {
        return status;
    }
}
