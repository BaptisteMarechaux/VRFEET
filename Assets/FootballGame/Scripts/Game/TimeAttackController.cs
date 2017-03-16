using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeAttackController : MonoBehaviour {

    [SerializeField]
    GameObject uiTimer;

    [SerializeField]
    GameObject uiBest;

    [SerializeField]
    float time;

    [SerializeField]
    int bestScore;

    [SerializeField]
    int bestShoot;

    [SerializeField]
    Text timerText;

    [SerializeField]
    Text bestText;

    [SerializeField]
    GameObject ballPrefab;

    [SerializeField]
    [Range(1,50)]
    int ballPollSize;

    float time_end;

    int gameState;

    GameObject[] ballsPool;

    int ballCursor;
    
	void Start ()
    {
        Reset();
	}
	
	void Update ()
    {
		if (gameState == 1)
        {
            var time_rest = time_end - Time.time;
            timerText.text = string.Format("{0:00}:{1:00}:{2:00}", Mathf.Floor(time_rest / 60), time_rest % 60, (time_rest * 10) % 10);

            if (time_rest <= 0)
            {
                gameState = 2;
                timerText.text = "00:00:00";

                var score = GameController.Instance.goal;
                var shoot = GameController.Instance.shoot;

                if (score > bestScore || (score == bestScore && shoot < bestShoot))
                {
                    bestScore = score;
                    bestShoot = shoot;
                }

                bestText.text = "PLAYER\n" + bestScore + " GOAL - " + bestShoot + " SHOOT";
            }
        }
	}

    public void Shoot()
    {
        if (gameState == 0)
        {
            time_end = Time.time + time;
            gameState = 1;
        }

        if (gameState == 1)
        {
            SpawnBall();
        }
    }

    public void SpawnBall()
    {
        if (ballCursor >= ballPollSize)
        {
            ballCursor = 0;
        }

        var physicBall = ballsPool[ballCursor].GetComponent<Rigidbody>();

        physicBall.MovePosition(GameController.Instance.BallSpawnPosition());
        physicBall.velocity = Vector3.zero;
        physicBall.angularVelocity = Vector3.zero;

        ballsPool[ballCursor].SetActive(true);
        ballCursor++;
    }

    public void Reset()
    {
        var controller = GameController.Instance;

        // Fill balls pool
        if (ballsPool == null)
        {
            ballsPool = new GameObject[ballPollSize];
            for (int i = 0; i < ballPollSize; i++)
            {
                ballsPool[i] = Instantiate(ballPrefab, controller.BallSpawnPosition(), Quaternion.identity) as GameObject;
                ballsPool[i].SetActive(false);
            }
        }
        else
        {
            for (int i = 0; i < ballPollSize; i++)
            {
                ballsPool[i].SetActive(false);
            }
        }

        ballCursor = 0;
        SpawnBall();

        // Refresh UI & score
        bestText.text = "PLAYER\n" + bestScore + " GOAL - " + bestShoot + " SHOOT";
        timerText.text = string.Format("{0:00}:{1:00}:{2:00}", Mathf.Floor(time / 60), time % 60, (time * 100) % 100);

        uiTimer.SetActive(true);
        uiBest.SetActive(true);

        gameState = 0;

        controller.shoot = 0;
        controller.goal = 0;

        controller.RefreshUI();
    }
}
