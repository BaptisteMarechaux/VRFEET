using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereItem : MonoBehaviour {
    public int pointAmount;

    [SerializeField]
    Renderer myRend;
    [SerializeField]
    AudioSource explosionSoundEffect;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider Col)
    {
        StartCoroutine(Explode(1.0f));
        BattleBaitManager.instance.points+=pointAmount;
    }

    IEnumerator Explode(float duration)
    {
        float elapsed=0;
        explosionSoundEffect.Play();
        while (elapsed < duration)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one * 2, elapsed / duration);
            myRend.material.color = Color.Lerp(myRend.material.color, new Color(255, 255, 255, 0), elapsed/duration);
            elapsed += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }
        Destroy(gameObject);
        yield return null;
    }
}
