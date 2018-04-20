using System;
using UnityEngine;
using HoloToolkit.Examples.InteractiveElements;
public class Bauteil_Rotator : MonoBehaviour {

    public ImageManager imgmanager; //stores current level
    public GestureInteractiveControl xAxis, yAxis;

    public GameObject[] bauteil; //list of component gameojects
    int prevX, prevY = 0;
    public GameObject xKnoble, yKnoble;
    private Vector3 xKnoble_standard, yKnoble_standard;
    public void Start()
    {
        xKnoble_standard = xKnoble.transform.localPosition;
        yKnoble_standard = yKnoble.transform.localPosition;
    }

    private int prev = 1;

    public void Update() {

        //check if lvl changed
        if(imgmanager.getLevel() != prev)
        {
            xKnoble.transform.localPosition = xKnoble_standard;
            yKnoble.transform.localPosition = yKnoble_standard;
            prev = imgmanager.getLevel();
        }

        int xr = Convert.ToInt32((xAxis.GetComponentInChildren(typeof(TextMesh)) as TextMesh).text);
        int yr = Convert.ToInt32((yAxis.GetComponentInChildren(typeof(TextMesh)) as TextMesh).text);
        if (prevX < xr) {
            //value has increased
            rotateX(1, xr);
            Debug.Log("rotate positiv prevX: " + prevX + ", xr: " + xr);
        }
        else if(prevX > xr)
        {
            //value has decreased
            rotateX(-1, xr);
            Debug.Log("rotate negative prevX: " + prevX + ", xr: " + xr);
        }

        if (prevY < yr)
        {
            //value has increased
            rotateY(1, yr);
            Debug.Log("rotate positiv prevY: " + prevY + ", yr: " + yr);
        }
        else if (prevY > yr)
        {
            //value has decreased
            rotateY(-1, yr);
            Debug.Log("rotate negative prevY: " + prevY + ", yr: " + yr);
        }

        prevY = yr;
        prevX = xr;
        
    }
    public void rotateX(int fac, int n) {
        int step = imgmanager.getLevel();
        bauteil[step - 1].transform.Rotate(0, 18 * fac, 0);
    }

    public void rotateY(int fac, int n)
    {
        int step = imgmanager.getLevel();
        bauteil[step - 1].transform.Rotate(18 * fac, 0, 0);
    }

}
