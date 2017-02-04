using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootCreateDrawWall : MonoBehaviour {

    [SerializeField]
    GameObject wall;

    [SerializeField]
    Rigidbody sourceRigidbody;

    [SerializeField]
    Transform positionToSpawn;

    [SerializeField]
    bool canCheckCollision;

    void OnCollisionEnter(Collision other)
    {
        float magnitude = Mathf.Log10(Vector3.SqrMagnitude(sourceRigidbody.velocity) + 1f) + 1f;

        if (canCheckCollision && magnitude > 1.0f && other.gameObject.tag == "Ground" && sourceRigidbody.velocity.y<-0.5f)
        {
            Debug.Log(sourceRigidbody.velocity.y);
            GameObject.Instantiate(wall, positionToSpawn.position, positionToSpawn.rotation* positionToSpawn.localRotation);
        }


    }



    void Start () {
        StartCoroutine(WaitForCollision());

    }

    IEnumerator WaitForCollision()
    {
        yield return new WaitForSeconds(2);
        canCheckCollision = true;
    }
	

	void Update () {
		
	}
}
