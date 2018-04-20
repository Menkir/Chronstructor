using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elementmanager : MonoBehaviour {

    public ImageManager imgmanager;
    private bool exploaded = false;
    private int prevStep = 1;
    private Transform currentElement;
    public play p;
    private int wait = 2;
    private IEnumerator coroutine;


    void Start() {
        //deactivat all elements instead of step 1
        for (int i = 1; i < transform.childCount; ++i) {
            foreach(Renderer r in transform.GetChild(i).GetComponentsInChildren<Renderer>())
            {
                r.enabled = false;
            }
        }

        currentElement = transform.GetChild(0);

        this.coroutine = this.currentElement.gameObject.GetComponent<ElementStartAnimation>().play(wait); // 2 seconds
    }

    int sem = 0; //counter which define play and stop beahaviour in Update()
    void Update() {
        
        if(sem == 0 && p.getStatus() == "play")
        {
            StartCoroutine(this.coroutine);
            ++sem;

        }

        if (sem == 1 && p.getStatus() != "play")
        {
            StopCoroutine(this.coroutine);
            --sem;

        }

        int currentStep = imgmanager.getLevel();
        if (currentStep != prevStep)
        {
            if(currentStep > transform.childCount) //make this dynamic
            {
                return;
            }
            switch_visibility(currentStep);
            //start animation
            this.coroutine = transform.GetChild(currentStep - 1).GetComponent<ElementStartAnimation>().play(wait);
            if(p.getStatus() == "play")
            {
                StartCoroutine(this.coroutine);
            }
            
            prevStep = currentStep;
        }

    }

    private void switch_visibility(int index){
        --index; //decrement because step != index

        //disable all elements
        for(int i = 0; i < transform.childCount; ++i)
        {
            //Debug.Log("Disable Step" + i);
            foreach (Renderer r in transform.GetChild(i).GetComponentsInChildren<Renderer>())
            {
                r.enabled = false;
            }
        }


        //enable current element
        foreach (Renderer r in transform.GetChild(index).GetComponentsInChildren<Renderer>())
        {
            r.enabled = true;
        }
        currentElement = transform.GetChild(index);

    }

    public void explode()
    {
        if (exploaded)
        {
            restore();
            return;
        }
        Transform parent = transform.GetChild(imgmanager.getLevel()-1); //current level object i.e Step (1) and so on
        try
        {
            parent.GetComponent<Animator>().Play(parent.gameObject.name);
            exploaded = true;
        } catch(UnityException e)
        {
            Debug.Log("You need to add a corresponding animation");
        }
        

        
    }

    public void restore()
    {
        Transform parent = transform.GetChild(imgmanager.getLevel()-1);

        try
        {
            parent.GetComponent<Animator>().Play(parent.gameObject.name + "_rev"); //play animation backwards
            exploaded = false;
        }
        catch (UnityException e)
        {
            Debug.Log("You need to add a corresponding reversed animation");
        }

    }
}
