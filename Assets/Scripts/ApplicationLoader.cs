using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationLoader : MonoBehaviour {

	public void load()
    {
        gameObject.transform.parent.gameObject.SetActive(false);
    }
}
