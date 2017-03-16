using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour {

    [SerializeField]
    GameController game;

    void OnTriggerEnter(Collider other)
    {
        BallScript ball = other.gameObject.GetComponent<BallScript>();

        if (ball)
        {
            if (game.GetGameMode() == GameController.GameMode.TIME_ATTACK)
            {
                ball.ResetBall(false, 0f, true);
            }
            else
            {
                ball.ResetBall(true, 0f, true);
            }

            game.Goal();
        }
    }
}
