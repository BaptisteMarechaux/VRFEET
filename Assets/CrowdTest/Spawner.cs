using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public int nbIA = 10;
    public GameObject IAPrefab;

    // Use this for initialization
    void Start () {
        int half = nbIA / 4;
        int x = -half;
        int z = -half;
        for (int i = 0; i < nbIA; i++)
        {
            GameObject.Instantiate(IAPrefab, transform.position + new Vector3(IAPrefab.transform.localScale.x*x*2, IAPrefab.transform.localScale.y*2, IAPrefab.transform.localScale.z*z*2), Quaternion.identity);
            x++;
            if (x >= 0)
            {
                z++;
                x = -half;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	}
}
