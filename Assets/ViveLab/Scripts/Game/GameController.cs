using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    [SerializeField]
    GameObject ballObject;

    [SerializeField]
    float resetBallAfter;

    [SerializeField]
    Text shootScore;

    [SerializeField]
    Text goalScore;

    public int goal = 0;

    public int shoot = 0;

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.Equals(ballObject))
        {
            BallScript ball = other.gameObject.GetComponent<BallScript>();
            ball.ResetBall(resetBallAfter);

            shoot++;
            shootScore.text = shoot.ToString();
        }
    }

    public void AddGoal()
    {
        goal++;
        goalScore.text = goal.ToString();
    }

}
