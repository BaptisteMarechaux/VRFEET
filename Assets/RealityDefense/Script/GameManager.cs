using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Manager
{

    private static Manager instance = null;

    public static int pv = 20;

    public static Manager GetInstance()
    {
        if (instance == null)
        {
            instance = new Manager();
        }

        return instance;
    }
}

public class GameManager : MonoBehaviour {

    [SerializeField]
    Color startColor;

    [SerializeField]
    Color endcolor;

    [SerializeField]
    GameObject lifeGameObjectColor;

    Renderer rd;

    /*[SerializeField]
    TextMesh pvText;*/

    [SerializeField]
    GameObject UIIntroduction;
    [SerializeField]
    Image UIIntroductionImage;
    [SerializeField]
    Text[] introductionTexts;
    [SerializeField]
    Text gameOverText;
    private int indexInstriductionTexts = 0;
    bool playingText = false;
    int introductionStep = 0;
    [SerializeField] GameObject titleText;
    bool canSpawnNewEnemies = false;

    [SerializeField]
    Text lifeText1;
    [SerializeField]
    Text lifeText2;

    [SerializeField]
    GameObject[] enemiesSpawners;
    private int transitionToEnd;

    void Awake()
    {
        Debug.Log(Manager.GetInstance());
    }

    // Use this for initialization
    void Start() {
        rd = lifeGameObjectColor.GetComponent<Renderer>();
        rd.material.color = startColor;
        rd.material.SetColor("_EmissionColor", Color.Lerp(startColor, endcolor, (20.0f - Manager.pv) / 20.0f));
        UIIntroduction.SetActive(true);
        titleText.SetActive(false);
        transitionToEnd = -1;
    }

    // Update is called once per frame
    void Update() {
        if (introductionStep == 0)
        {
            if (!playingText)
            {
                if (indexInstriductionTexts >= introductionTexts.Length)
                {
                    introductionStep = 1;
                }
                else
                {
                    playingText = true;
                    StartCoroutine(WaitAndChangeIntrodcutionText());
                }
            }
            else
            {
                introductionTexts[indexInstriductionTexts].color = new Color(introductionTexts[indexInstriductionTexts].color.r, introductionTexts[indexInstriductionTexts].color.g, introductionTexts[indexInstriductionTexts].color.b, introductionTexts[indexInstriductionTexts].color.a + 0.5f * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.Space))
            {
                for (int i = 0; i < introductionTexts.Length; i++)
                {
                    introductionTexts[i].gameObject.SetActive(false);
                } 
                introductionStep = 2;
            }
        }
        else
        {
            if (introductionStep == 1)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    introductionStep = 2;
                }
            }

            if (introductionStep == 2)
            {
                if(indexInstriductionTexts>0)
                    introductionTexts[indexInstriductionTexts - 1].gameObject.SetActive(false);
                canSpawnNewEnemies = true;
                titleText.SetActive(true);
                introductionStep = 3;
            }

            if (introductionStep == 3)
            {
                UIIntroductionImage.color = new Color(UIIntroductionImage.color.r, UIIntroductionImage.color.g, UIIntroductionImage.color.b, UIIntroductionImage.color.a - 0.5f * Time.deltaTime);
                if(UIIntroductionImage.color.a <= 0)
                {
                    introductionStep = 4;
                }
            }

            if (canSpawnNewEnemies)
            {
                StartCoroutine(SpawnAndWait());
                canSpawnNewEnemies = false;
            }
        }

        //pvText.text = "HP: " +  Manager.pv.ToString();
        //lifeGameObjectColor.GetComponent<Renderer>().material = Color.Lerp(startColor, endcolor, 0.00001f);
        //float lerp = Mathf.PingPong(Time.time, 1.0f) / 1.0f;
        //lifeGameObjectColor.GetComponent<Renderer>().material.color = Color.Lerp(startColor, endcolor, 0.1f);

        if (Manager.pv <= 20 && Manager.pv >= 0)
        {
            rd.material.color = Color.Lerp(startColor, endcolor, (20.0f - Manager.pv) / 20.0f);
            rd.material.SetColor("_EmissionColor", Color.Lerp(startColor, endcolor, (20.0f - Manager.pv) / 20.0f));
            lifeText1.color = rd.material.color;
            lifeText1.color = new Color(lifeText1.color.r, lifeText1.color.g, lifeText1.color.b, 1);
            lifeText2.color = rd.material.color;
            lifeText2.text = Manager.pv.ToString();
            lifeText2.color = new Color(lifeText2.color.r, lifeText2.color.g, lifeText2.color.b, 1);
        }

        if (Manager.pv == 0)
        {
            Manager.pv = -1;
            transitionToEnd = 0;
            StartCoroutine(WaitSecondsBeforeEnd());
            //Manager.pv = 20;
            //SceneManager.LoadScene(0);
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            transitionToEnd = 0;
            StartCoroutine(WaitSecondsBeforeEnd());
        }

        if(transitionToEnd == 0)
        {
            gameOverText.gameObject.SetActive(true);
            if(UIIntroductionImage.color.a >= 0.8f)
                gameOverText.color = new Color(gameOverText.color.r, gameOverText.color.g, gameOverText.color.b, gameOverText.color.a + 0.4f * Time.deltaTime);
            UIIntroductionImage.color = new Color(UIIntroductionImage.color.r, UIIntroductionImage.color.g, UIIntroductionImage.color.b, UIIntroductionImage.color.a + 0.5f * Time.deltaTime);
        }
        else if (transitionToEnd == 1)
        {
            SceneManager.LoadScene(0);
        }
    }

    private IEnumerator WaitSecondsBeforeEnd()
    {
        titleText.SetActive(false); 
        gameOverText.color = new Color(gameOverText.color.r, gameOverText.color.g, gameOverText.color.b, 0);
        yield return new WaitForSeconds(5.0f);
        transitionToEnd = 1;
    }

    IEnumerator WaitAndChangeIntrodcutionText()
    {
        if (indexInstriductionTexts > 0)
            introductionTexts[indexInstriductionTexts - 1].gameObject.SetActive(false);
        introductionTexts[indexInstriductionTexts].color = new Color(introductionTexts[indexInstriductionTexts].color.r, introductionTexts[indexInstriductionTexts].color.g, introductionTexts[indexInstriductionTexts].color.b, 0.0f);
        introductionTexts[indexInstriductionTexts].gameObject.SetActive(true);
        yield return new WaitForSeconds(4.0f);
        playingText = false;
        indexInstriductionTexts++;
    }

    IEnumerator SpawnAndWait()
    {
        for (int i = 0; i < enemiesSpawners.Length; i++)
        {
            enemiesSpawners[i].SetActive(true);
        }
        yield return new WaitForSeconds(60.0f);
        for (int i = 0; i < enemiesSpawners.Length; i++)
        {
            enemiesSpawners[i].SetActive(false);
        }
        canSpawnNewEnemies = true;
    }

}
