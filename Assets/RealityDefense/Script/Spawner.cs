using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public int nbIA = 10;
    public GameObject IAPrefab;

    int half = 0;
    int x = 0;
    int z = 0;
    int i = 0;

    // Use this for initialization
    void OnEnable () {
        half = nbIA / 4;
        x = -half;
        z = -half;
        i = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if(i < nbIA)
        {
            if (Random.Range(0.0f, 1.0f) >= 0.8f)
            {
                GameObject.Instantiate(IAPrefab, transform.position + new Vector3(IAPrefab.transform.localScale.x * x * 2, IAPrefab.transform.localScale.y * 2, IAPrefab.transform.localScale.z * z * 2), Quaternion.identity);
                x++;
                if (x >= 0)
                {
                    z++;
                    x = -half;
                }
                i++;
            }
        }
    }
}
