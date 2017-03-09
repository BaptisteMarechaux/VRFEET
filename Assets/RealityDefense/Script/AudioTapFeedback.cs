using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTapFeedback : MonoBehaviour
{

    [SerializeField]
    AudioSource audioFeedback;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision other)
    {
        audioFeedback.Play();
    }
}
