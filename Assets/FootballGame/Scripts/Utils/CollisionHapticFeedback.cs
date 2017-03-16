using UnityEngine;
using System.Collections;

public class CollisionHapticFeedback : MonoBehaviour {

    [SerializeField]
    ViveHapticFeedback hapticController;

    [SerializeField]
    Rigidbody sourceRigidbody;

    [SerializeField]
    float forceRatio = 1f;

    [SerializeField]
    float vibrationDuration = 1.5f;

    void OnCollisionEnter(Collision other)
    {
        float magnitude = Mathf.Log10(Vector3.SqrMagnitude(sourceRigidbody.velocity) * forceRatio + 1f) + 1f;
        float pulseForce = 3999f * (1f - (1f / magnitude));

        hapticController.Pulse(vibrationDuration, (ushort) pulseForce);
    }

    /* >> Not required for this demo
    void OnCollisionStay(Collision other)
    {
        if ( ! hapticController.isPulsing)
        {
            float magnitude = Mathf.Log10(Vector3.SqrMagnitude(sourceRigidbody.velocity) * forceRatio + 1f) + 1f;
            float pulseForce = 3999f * (1f - (1f / magnitude));

            if (magnitude > 250f)
            {
                hapticController.Pulse(vibrationDuration, (ushort) (pulseForce * 0.25f));
            }
        }
    }*/
}
