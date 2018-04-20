using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepController : MonoBehaviour {

    public TimelineController tc;
    public int step;

    private List<float> indices = new List<float>();
	// Use this for initialization
	void Start () {
        if(step <= 0 || step > transform.parent.childCount)
        {
            Debug.Log("Step should be between 1 and 7");
            return;
        }

        indices.Add(-0.4033f);
        indices.Add(-0.3664f);
        indices.Add(-0.3295f);
        indices.Add(-0.2941f);
        indices.Add(-0.188f);
        indices.Add(-0.0885f);
        indices.Add(0);
        indices.Add(0.0885f);
        indices.Add(0.188f);
        indices.Add(0.2941f);
        indices.Add(0.3295f);
        indices.Add(0.3664f);
        indices.Add(0.4033f);
    }
	
	// Update is called once per frame
	void Update () {
		if(tc.getLevel() == step)
        {
            transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
            transform.GetComponent<SpriteRenderer>().sprite = tc.status_sprites[0];
        } else
        {
            transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
        }

	}

    public void stepForward()
    {
        if(tc.getLevel() > 7)
        {
            return;
        }
        transform.localPosition = new Vector3(getNextCoordRev(), 0,0);
        if(transform.localPosition.x < 0f)
        {
            transform.GetComponent<SpriteRenderer>().sprite = tc.status_sprites[2];
        }
    }

    public void stepBackward()
    {
        if (tc.getLevel() > 7)
        {
            return;
        }
        transform.localPosition = new Vector3(getNextCoord(), 0, 0);
        if (transform.localPosition.x > 0f)
        {
            transform.GetComponent<SpriteRenderer>().sprite = tc.status_sprites[1];
        }
    }

    private float getNextCoord()
    {
        for (int i = 0; i < indices.Count; ++i)
        {
            if (transform.localPosition.x < indices[i])
            {
                return indices[i];
            }
        }

        return 0f;
    }

    private float getNextCoordRev()
    {
        for(int i = indices.Count-1; i >= 0; --i)
        {
            if(transform.localPosition.x > indices[i])
            {
                return indices[i];
            }
        }

        return 0f;
    }
}
