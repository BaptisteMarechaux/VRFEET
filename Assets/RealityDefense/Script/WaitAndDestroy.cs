using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitAndDestroy : MonoBehaviour {

    [SerializeField] float secondsBeforeDestroy = 2.0f;

	// Use this for initialization
	void Start () {
        StartCoroutine(_WaitAndDestroy());
	}

    IEnumerator _WaitAndDestroy()
    {
        yield return new WaitForSeconds(secondsBeforeDestroy);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
