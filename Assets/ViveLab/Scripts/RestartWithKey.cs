using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartWithKey : MonoBehaviour {

    [SerializeField]
    KeyCode restartKey;

    [SerializeField]
    GameController controller;

    bool keypPressed = false;

	void Update ()
    {
        keypPressed = Input.GetKeyDown(restartKey);	
	}

    void FixedUpdate()
    {
        if (keypPressed)
            controller.Reset();
    }
}
