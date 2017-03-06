using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VersusController : MonoBehaviour {

    [SerializeField]
    GameObject uiScore;

    [SerializeField]
    Text player1Name;

    [SerializeField]
    Image[] player1Goals;

    [SerializeField]
    Text player2Name;

    [SerializeField]
    Image[] player2Goals;

    [SerializeField]
    GameObject uiWinner;

    [SerializeField]
    Text winnerText;

    int player1_score;
    int player1_miss;

    int player2_score;
    int player2_miss;

    int max_shoot;

    int gameState;

	void Start ()
    {
        Reset();
	}

    void FixedUpdate()
    {
        if (gameState == 0)
        {
            var shoot = player1_score + player1_miss;

            if (shoot >= max_shoot)
            {
                gameState = 1;

                player1Name.color = Color.white;
                player2Name.color = Color.green;

                GameController controller = GameController.Instance;
                controller.shoot = 0;
                controller.goal = 0;
                controller.RefreshUI();
            }
        }
        else if (gameState == 1)
        {
            var shoot = player2_score + player2_miss;

            if (shoot >= max_shoot)
            {
                gameState = 2;

                if (player1_score > player2_score)
                {
                    winnerText.text = "Winner - Player 1";
                }
                else if (player2_score > player1_score)
                {
                    winnerText.text = "Winner - Player 2";
                }
                else
                {
                    winnerText.text = "Draw";
                }

                uiWinner.SetActive(true);
            }
        }
    }

    public void Miss()
    {
        if (gameState == 0)
        {
            player1_miss++;
            player1Goals[player1_miss + player1_score - 1].color = Color.red;
        }
        else if (gameState == 1)
        {
            player2_miss++;
            player2Goals[player2_miss + player2_score - 1].color = Color.red;
        }
    }

    public void Goal()
    {
        if (gameState == 0)
        {
            player1_score++;
            player1Goals[player1_miss + player1_score - 1].color = Color.green;
        }
        else if (gameState == 1)
        {
            player2_score++;
            player2Goals[player2_miss + player2_score - 1].color = Color.green;
        }
    }

    public void Reset()
    {
        player1_score = 0;
        player1_miss = 0;
        player2_score = 0;
        player2_miss = 0;


        player1Name.color = Color.green;
        player2Name.color = Color.white;

        for (int i = 0; i < player1Goals.Length; i++)
        {
            player1Goals[i].color = Color.white;
            player2Goals[i].color = Color.white;
        }

        max_shoot = player1Goals.Length;
        gameState = 0;

        uiScore.SetActive(true);
        uiWinner.SetActive(false);
    }

}
