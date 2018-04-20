using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {
    public TimelineController tlc;
	// Update is called once per frame
	void Update () {
        transform.GetComponent<SpriteRenderer>().sprite = tlc.number_sprites[tlc.getLevel()];
	}
}
