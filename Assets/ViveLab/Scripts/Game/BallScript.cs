using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {

    [SerializeField]
    Rigidbody physic;

    Vector3 startPosition;

    float resetTimer = 0;

    bool resetEnable = false;

	void Start () {
        startPosition = transform.position;
	}
	
	void FixedUpdate()
    {
        if (resetEnable && resetTimer < Time.time)
        {
            physic.MovePosition(startPosition);

            physic.velocity = Vector3.zero;
            physic.angularVelocity = Vector3.zero;

            resetEnable = false;
        }
    }

    public void ResetBall(float timer)
    {
        resetTimer = Time.time + timer;
        resetEnable = true;
    }

}
