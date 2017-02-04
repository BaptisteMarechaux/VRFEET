using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour {

    [SerializeField]
    float scaleMax = 0.5f;

    [SerializeField]
    float speedGrow = 0.3f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.localScale.x < scaleMax)
        {
            transform.localScale = new Vector3(transform.localScale.x + speedGrow * Time.deltaTime, transform.localScale.y, transform.localScale.z);
        }
	}
}
