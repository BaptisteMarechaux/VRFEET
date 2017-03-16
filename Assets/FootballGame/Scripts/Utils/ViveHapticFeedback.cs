using UnityEngine;
using System.Collections;

public class ViveHapticFeedback : MonoBehaviour {

    SteamVR_TrackedObject vrControllerObject;

    SteamVR_Controller.Device vrController
    {
        get
        {
            if (vrControllerObject.isActiveAndEnabled)
            {
                return SteamVR_Controller.Input((int)vrControllerObject.index);
            }
            else { return null; }
        }
    }

    public bool isPulsing = false;

    ushort pulseForce = 1500;

    float pulseDuration = 0.1f;
    float pulseUntil = 0f;
    float nextPulse;

    [Range(0.04f, 1f)]
    [SerializeField]
    float pulseFrequency;

    void Start () {
        vrControllerObject = GetComponent<SteamVR_TrackedObject>();
        nextPulse = Time.time;
	}

    void FixedUpdate()
    {
        isPulsing = pulseUntil > Time.time;

        if (isPulsing && nextPulse < Time.time)
        {
            vrController.TriggerHapticPulse(pulseForce);
            nextPulse = Time.time + pulseFrequency;
        }
    }

    public void Pulse(float duration = 0.1f, ushort force = 1500)
    {
        if (isPulsing)
        {
            if (force > pulseForce)
            {
                pulseForce = force;
            }
            if (duration + Time.time > pulseUntil)
            {
                pulseUntil = duration + Time.time;
            }
        }
        else
        {
            pulseForce = force;
            pulseUntil = duration + Time.time;
        }
    }

}
