using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootCreateDrawWall : MonoBehaviour {

    [SerializeField]
    GameObject wall;

    [SerializeField]
    GameObject wave;

    [SerializeField]
    Rigidbody sourceRigidbody;

    [SerializeField]
    Transform positionToSpawn;

    [SerializeField]
    bool canCheckCollision;

    [SerializeField]
    bool onCollision;

    public
    Vector3 oldPosition = new Vector3(0,0,0);

    void OnCollisionEnter(Collision other)
    {
        float magnitude = Mathf.Log10(Vector3.SqrMagnitude(sourceRigidbody.velocity) + 1f) + 1f;

        if (canCheckCollision && magnitude > 0.5f && other.gameObject.tag == "Ground" && sourceRigidbody.velocity.y<-0.5f)
        {
            Debug.Log(sourceRigidbody.velocity.y);
            GameObject.Instantiate(wave, transform.position, positionToSpawn.rotation* positionToSpawn.localRotation);
        }

        if(other.gameObject.tag == "Ground")
        {
            onCollision = true;
            oldPosition = this.transform.position;
        }
    }

    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Ground")
            onCollision = true;
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            onCollision = false;
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
        if (onCollision)
        {
            if(Vector3.Distance(oldPosition, this.transform.position) > 0.1)
            {
                Debug.Log(Vector3.Distance(oldPosition, this.transform.position));
                oldPosition = this.transform.position;
                if (sourceRigidbody.velocity.y > -0.4f /*&& sourceRigidbody.velocity.y < 0.1f*/)
                {
                    //GameObject.Instantiate(wall, positionToSpawn.position, positionToSpawn.rotation * positionToSpawn.localRotation);
                    oldPosition = this.transform.position;
                }
            }

        }
	}
}
