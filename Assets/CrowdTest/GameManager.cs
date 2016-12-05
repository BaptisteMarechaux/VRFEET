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
    TextMesh pvText;

    void Awake()
    {
        Debug.Log(Manager.GetInstance());
    }

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        pvText.text = "HP: " +  Manager.pv.ToString();
        if(Manager.pv == 0)
        {
            Manager.pv = 20;
            SceneManager.LoadScene(0);
        }
	}
}
