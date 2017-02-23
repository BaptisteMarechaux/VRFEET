using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour {

    [SerializeField]
    float scaleMax = 0.5f;

    [SerializeField]
    float speedGrow = 0.3f;

    [SerializeField]
    float startToGrow = 0.0f;
    float currentGrowDuration = 0.0f;
    [SerializeField]
    float growDuration = 2.0f;
    bool isGrowing = true;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(currentGrowDuration >= startToGrow)
        {
            if (isGrowing)
            {
                if (transform.localScale.x < scaleMax)
                {
                    transform.localScale = new Vector3(transform.localScale.x + scaleMax / growDuration * Time.deltaTime, transform.localScale.y, transform.localScale.z);
                }
                else
                {
                    isGrowing = false;
                }
            }
            else
            {
                if ((transform.localScale.x - scaleMax / growDuration * Time.deltaTime) >= 0.0f)
                {
                    transform.localScale = new Vector3(transform.localScale.x - scaleMax / growDuration * Time.deltaTime, transform.localScale.y, transform.localScale.z);
                }
                else
                {
                    Destroy(gameObject);
                }
            }
        }
        else
        {
            currentGrowDuration += Time.deltaTime;
        }
	}
}
