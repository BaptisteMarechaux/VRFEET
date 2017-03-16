using UnityEngine;
using System.Collections;

public class CustomJoinObjectTo : MonoBehaviour {

    [Range(0f,100f)]
    [SerializeField]
    float joinForce = 50f;

    [SerializeField]
    Rigidbody targetRigidbody;

    [SerializeField]
    Vector3 anchorOffset;

    [SerializeField]
    Vector3 anchorRotation;

    Transform targetTransform;
    
    void Start () {
        targetTransform = targetRigidbody.transform;
	}

    void FixedUpdate()
    {
        targetRigidbody.rotation = transform.rotation * Quaternion.Euler(anchorRotation.x, anchorRotation.y, anchorRotation.z);

        Vector3 targetPosition = transform.TransformDirection(anchorOffset) + transform.position;

        float force = (joinForce - targetRigidbody.mass < 0f) ? 0f : joinForce - targetRigidbody.mass;
        targetRigidbody.velocity = (targetTransform.position - targetPosition) * force * -1f;
    }

}
