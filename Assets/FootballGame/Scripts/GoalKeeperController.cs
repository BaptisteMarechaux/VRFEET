using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalKeeperController : MonoBehaviour {

    [SerializeField]
    Rigidbody physic;

    [SerializeField]
    [Range(0f,10f)]
    float speed;

    [SerializeField]
    [Range(0f,10f)]
    float jumpForce;

    [SerializeField]
    float movementRangeX;

    Vector3 startPosition;

    float movingAxis;

    bool isGrounded;

    float jumpAxis;

    void Start()
    {
        startPosition = transform.localPosition;
        isGrounded = true;
    }
	
	void Update ()
    {
        movingAxis = Input.GetAxis("Horizontal");
        jumpAxis = Input.GetAxis("Jump");
	}

    void FixedUpdate()
    {
        var velocityX = 1f * movingAxis * speed;
        if ((transform.localPosition.z < startPosition.z + movementRangeX || velocityX < 0f)
            && (transform.localPosition.z > startPosition.z - movementRangeX || velocityX > 0f))
        {
            physic.velocity = new Vector3(physic.velocity.x, physic.velocity.y, 1f * movingAxis * speed);
        }
        else
        {
            physic.velocity = new Vector3(physic.velocity.x, physic.velocity.y, 0f);
        }


        if (isGrounded && jumpAxis > 0f)
        {
            physic.AddForce(new Vector3(0f, 100f * jumpAxis * jumpForce, 0f));
            isGrounded = false;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if ( ! isGrounded)
        {
            if (other.transform.position.y < transform.position.y)
            {
                isGrounded = true;
            }
        }
    }

}
