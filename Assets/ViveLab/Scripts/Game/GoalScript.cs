using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour {

    [SerializeField]
    GameObject ballObject;

    [SerializeField]
    GameController game;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.Equals(ballObject))
        {
            BallScript ball = other.gameObject.GetComponent<BallScript>();
            ball.ResetBall(0f);
            game.AddGoal();
        }
    }
}
