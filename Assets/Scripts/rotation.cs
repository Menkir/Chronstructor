using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour {
    public GameObject xBar, yBar;

	public void switch_visibility()
    {
        if (!xBar.activeInHierarchy)
        {
            yBar.SetActive(true);
            xBar.SetActive(true);
        }
        else
        {
            xBar.SetActive(false);
            yBar.SetActive(false);
        }
    }
}
