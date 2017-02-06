using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public enum GameMode { TRAINING, TIME_ATTACK, VERSUS }

    [SerializeField]
    GameMode gameMode;

    [SerializeField]
    TimeAttackController timeAttackModeController;

    [SerializeField]
    VersusController versusModeController;

    [SerializeField]
    Transform ballSpawn;

    [SerializeField]
    float resetBallAfter;

    [SerializeField]
    Text shootScore;

    [SerializeField]
    Text goalScore;

    [SerializeField]
    GameObject ballPrefab;

    public int goal = 0;

    public int shoot = 0;

    GameMode currentGameMode;

    #region UnityCompliant Singleton
    public static GameController Instance
    {
        get;
        private set;
    }

    public virtual void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            return;
        }

        Destroy(this.gameObject);
    }
    #endregion

    public GameMode GetGameMode()
    {
        return currentGameMode;
    }

    public Vector3 BallSpawnPosition()
    {
        return ballSpawn.position;
    }

    void Start()
    {
        currentGameMode = gameMode;

        if (currentGameMode == GameMode.VERSUS)
        {
            Instantiate(ballPrefab, BallSpawnPosition(), Quaternion.identity);
            versusModeController.enabled = true;
        }
        else if (currentGameMode == GameMode.TIME_ATTACK)
        {
            timeAttackModeController.enabled = true;
        }
        else
        {
            Instantiate(ballPrefab, BallSpawnPosition(), Quaternion.identity);
        }
    }

    void OnTriggerExit(Collider other)
    {
        BallScript ball = other.gameObject.GetComponent<BallScript>();

        if (ball)
        {
            if (currentGameMode == GameMode.TIME_ATTACK)
            {
                ball.ResetBall(false, resetBallAfter);
                timeAttackModeController.Shoot();
            }
            else
            {
                ball.ResetBall(true, resetBallAfter);
            }

            shoot++;
            RefreshUI();
        }
    }

    public void RefreshUI()
    {
        goalScore.text = goal.ToString();
        shootScore.text = shoot.ToString();
    }

    public void Goal()
    {
        if (currentGameMode == GameMode.VERSUS)
        {
            versusModeController.Goal();
        }

        goal++;
        RefreshUI();
    }

    public void Miss()
    {
        if (currentGameMode == GameMode.VERSUS)
        {
            versusModeController.Miss();
            Debug.Log("1");
        }
    }

    public void Reset()
    {
        goal = 0;
        shoot = 0;

        RefreshUI();

        if (currentGameMode == GameMode.VERSUS)
        {
            versusModeController.Reset();
        }
        else if (currentGameMode == GameMode.TIME_ATTACK)
        {
            timeAttackModeController.Reset();
        }
    }

}
