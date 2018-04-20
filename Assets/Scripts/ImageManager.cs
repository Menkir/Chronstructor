using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Vuforia;

public class ImageManager : MonoBehaviour {
    public List<ChronTrackableEventHandler> imageTargetList;
	private int level = 1;
	public Dictionary<int, Dictionary<string, bool>> permissionList; //Step, element and If its tracked by vuforia
    public bool rendering = false;

	public void Start(){
		permissionList = new Dictionary<int, Dictionary<string, bool>>();
        //TODO: Serialize over Json
        Dictionary<string, bool> step1 = new Dictionary<string, bool>();
        step1.Add("Getriebegehaeuse", false);
        step1.Add("Unterlegscheibe", false);
        step1.Add("Drehteil", false);
        permissionList.Add(1, step1);
        Dictionary<string, bool> step2 = new Dictionary<string, bool>();
        step2.Add("Ring", false);
        step2.Add("Deckel", false);
        permissionList.Add(2, step2);
        Dictionary<string, bool> step3 = new Dictionary<string, bool>();
        step3.Add("SchraubeM4x12", false);
        permissionList.Add(3, step3);
        Dictionary<string, bool> step4 = new Dictionary<string, bool>();
        step4.Add("SchraubeM4x8", false);
        step4.Add("Riemenrad", false);
        permissionList.Add(4, step4);
        Dictionary<string, bool> step5 = new Dictionary<string, bool>();
        step5.Add("Motor", false);
        step5.Add("Bremse", false);
        step5.Add("SchraubeM3x12", false);
        permissionList.Add(5, step5);
        Dictionary<string, bool> step6 = new Dictionary<string, bool>();
        step6.Add("Dichtung", false);
        step6.Add("SchraubeM4x12", false);
        permissionList.Add(6, step6);
        Dictionary<string, bool> step7 = new Dictionary<string, bool>();
        step7.Add("Montagesockel", false);
        step7.Add("SchraubeM5x12", false);
        permissionList.Add(7, step7);
    }

    public void switchRendering()
    {
        rendering = !rendering;
    }


	public void proceed(){
        ++level;
        //switchRendering();
        //clean view 
        foreach (ChronTrackableEventHandler handler in imageTargetList) {
                handler.OnTrackableStateChanged(TrackableBehaviour.Status.TRACKED, TrackableBehaviour.Status.NOT_FOUND);
        }
    }

	/**
	Check if current tracked Object should be renderd.
	*/
	public bool renderAllowed(string trackedObj){

        if(level > permissionList.Count || !rendering)
        {
            return false;
        }
        foreach(KeyValuePair<string, bool> e in permissionList[level])
        {
            if (e.Key.Contains(trackedObj))
            {
                Debug.Log(e.Key + " is in " +trackedObj);
                return true;
            }
        }

        return false;
	}

    public int getLevel() { return level; }
    public void setLevel(int level) { this.level = level; }

    public bool IsScanning()
    {

        if(level > permissionList.Count)
        {
            return true;
        }
        try
        {
            foreach(KeyValuePair<string, bool> entry in permissionList[level])
            {
                if (!entry.Value)
                {
                    return true;
                }
            }
            return false;

        } catch(KeyNotFoundException e)
        {
            Debug.Log(e);
        }

        return true;
    }
}
