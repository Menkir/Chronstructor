using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GifAnimator : MonoBehaviour {
    public GameObject UI, ARCamera;
    private List<Sprite>  frames = new List<Sprite>();
    public TimelineController timeline;
    public ImageManager img;
    public int framerate = 30;

    private List<Sprite> anim = new List<Sprite>();

    private void Start()
    {
        string temp = "";
        for(int i = 0; i < 226; ++i)
        {
            if (i < 10)
            {
                temp = "00" + i;
            }
            else if (i < 100)
            {
                temp = "0" + i;
            }
            else
                temp = "" + i;
            Sprite loaded = Resources.Load<Sprite>("success/frame_" + temp + "_delay-0.04s");
            frames.Add(loaded);
        }

        for(int i = 0; i< 65; ++i)
        {
            anim.Add(frames[i]);
        }
        for (int i = 0; i < 65; ++i)
        {
            anim.Add(frames[64-i]);
        }

        transform.GetComponentInParent<SpriteRenderer>().enabled = false;
    }

    void Update () {

        if (img.IsScanning())
        {
            //transform.GetComponentInParent<SpriteRenderer>().enabled = true;
            UI.SetActive(false);

            int index = (int)(Time.time * framerate) % 130;

            transform.GetComponent<SpriteRenderer>().sprite = anim[index];

        } else
        {
            transform.GetComponentInParent<SpriteRenderer>().enabled = false;
            UI.SetActive(true);
        }

        if(img.getLevel() > timeline.Steps)
        {
            int index = (int)(Time.time * framerate) % frames.Count;

            transform.GetComponent<SpriteRenderer>().sprite = frames[index];

            if(index > 200)
            {
                Application.Quit();
            }
        }
       
	}
}
