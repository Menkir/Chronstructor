using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using UnityEngine.EventSystems;
using System;

public class GazeObserver : MonoBehaviour {
    public GameObject cont, expl;
    private Animator previous_animator = null;
    private string previous_name = "";
    private bool played = false;

	void Update () {

        BaseEventData data = new BaseEventData(EventSystem.current);
        GameObject o = FocusManager.Instance.TryGetFocusedObject(data);
        if(o != null)
        {
            if (o.name == "Utility" && !played)
            {
                previous_animator = o.transform.GetComponent<Animator>();
                previous_name = "highlight_utility";
                previous_animator.Play(previous_name);
                played = true;
            }

            if (o.name == "Continue" && !played)
            {
                previous_animator = o.transform.GetComponent<Animator>();
                previous_name = "highlight";
                previous_animator.Play(previous_name);
                played = true;
            }

            if (o.name == "Explode" && !played)
            {
                previous_animator = o.transform.GetComponent<Animator>();
                previous_name = "highlight_explosion";
                previous_animator.Play(previous_name);
                played = true;
            }

            if (o.name == "Play" && !played)
            {
                previous_animator = o.transform.GetComponent<Animator>();
                previous_name = "highlight_play";
                previous_animator.Play(previous_name);
                played = true;
            }

            if (o.name == "Rotate" && !played)
            {
                previous_animator = o.transform.GetComponent<Animator>();
                previous_name = "highlight_rotate";
                previous_animator.Play(previous_name);
                played = true;
            }
        } else
        {
            try
            {
                if (played)
                {
                    Debug.Log(previous_name);
                    previous_animator.Play(previous_name + "_rev");

                    previous_name = "";
                    previous_animator = null;
                    played = false;
                }
            } catch (NullReferenceException e) {
                Debug.Log(e);
            }
        }
    }
}
