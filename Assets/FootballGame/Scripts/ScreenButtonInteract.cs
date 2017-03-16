using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ScreenButtonInteract : MonoBehaviour {

    [SerializeField]
    Image background;

    public bool hold = false;

    public bool click = false;

    [SerializeField]
    UnityEvent onClick;

    void Start ()
    {
        if (onClick == null)
            onClick = new UnityEvent();
        onClick.AddListener(OnClick);
	}
	
	void Update ()
    {
		if (click)
        {
            onClick.Invoke();
            click = false;
        }
	}

    void OnClick()
    {
        Debug.Log("Clicked");
    }


}
