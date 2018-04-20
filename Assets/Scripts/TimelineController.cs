using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Examples.InteractiveElements;
public class TimelineController : MonoBehaviour {
    public ImageManager imgTargetManager; 
    public int Steps = 1;
    public List<Sprite> status_sprites = new List<Sprite>();
    public List<Sprite> number_sprites = new List<Sprite>();
    private int level = 1;
    private enum STATUS: int { CURRENT, NEXT, PREV }
    public bool finish = false;

    public void proceed()
    {
        ++level;
        for (int i = 0; i< transform.childCount; ++i)
        {
            transform.GetChild(i).GetComponent<StepController>().stepForward();
        }

        
        if (level >= Steps)
        {
            finish = true;
            return;
        }

       
       
    }

    public void jumpToStep(GameObject o)
    {
        int level = 1;
        for(int i = 0; i< transform.childCount; ++i)
        {
            Debug.Log("Check if " + o + " == " + transform.GetChild(i).gameObject);
            if(o == transform.GetChild(i).gameObject)
            {
                level = i + 1;
                break;
            }
        }
        Debug.Log("Jumpt to " + level);
        imgTargetManager.setLevel(level);
    }

    public int getLevel()
    {
        return level;
    }

}
