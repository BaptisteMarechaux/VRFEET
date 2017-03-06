using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {

    [SerializeField]
    Rigidbody physic;

    Vector3 startPosition;

    float resetTimer = 0;

    bool resetByGoal = false;

    bool resetEnable = false;

    bool resetPostion = true;

	void Start ()
    {
        startPosition = transform.position;
	}
	
	void FixedUpdate()
    {
        if (resetEnable && resetTimer < Time.time)
        {
            if (resetPostion)
            {
                physic.MovePosition(startPosition);

                physic.velocity = Vector3.zero;
                physic.angularVelocity = Vector3.zero;

                resetEnable = false;
            }

            if (!resetByGoal)
            {
                GameController.Instance.Miss();
            }
        }

    }

    public void ResetBall(bool reset, float timer, bool goal = false)
    {
        resetTimer = Time.time + timer;
        resetEnable = true;
        resetPostion = reset;
        resetByGoal = goal;
    }

}
