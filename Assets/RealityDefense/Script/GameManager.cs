using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    void Awake()
    {
        Debug.Log(Manager.GetInstance());
    }

    // Use this for initialization
    void Start () {
        rd = lifeGameObjectColor.GetComponent<Renderer>();
        rd.material.color = startColor;
        rd.material.SetColor("_EmissionColor", Color.Lerp(startColor, endcolor, (20.0f - Manager.pv) / 20.0f));
    }
	
	// Update is called once per frame
	void Update () {
        //pvText.text = "HP: " +  Manager.pv.ToString();
        //lifeGameObjectColor.GetComponent<Renderer>().material = Color.Lerp(startColor, endcolor, 0.00001f);
        //float lerp = Mathf.PingPong(Time.time, 1.0f) / 1.0f;
        //lifeGameObjectColor.GetComponent<Renderer>().material.color = Color.Lerp(startColor, endcolor, 0.1f);

        if (Manager.pv < 20)
        {
            rd.material.color = Color.Lerp(startColor, endcolor, (20.0f - Manager.pv)/20.0f);
            rd.material.SetColor("_EmissionColor", Color.Lerp(startColor, endcolor, (20.0f - Manager.pv) / 20.0f));
        }

        if (Manager.pv == 0)
        {
            //Manager.pv = 20;
            //SceneManager.LoadScene(0);
        }
	}
}
