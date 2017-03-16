using UnityEngine;
using System.Collections;

public class MoveWithViveController : MonoBehaviour {

    [SerializeField]
    SteamVR_TrackedObject vrControllerObject;

    [SerializeField]
    ViveHapticFeedback controllerLeft;

    [SerializeField]
    ViveHapticFeedback controllerRight;

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

    Valve.VR.EVRButtonId touchpadButtonID = Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad;
    bool touchpadButtonPressed = false;

    [SerializeField]
    Rigidbody physic;

    [SerializeField]
    Transform HMDTransform;

    [SerializeField]
    [Range(0.1f, 5f)]
    float moveSpeed;
	
	void Update () {
        if (vrController != null)
        {
            touchpadButtonPressed = vrController.GetPress(touchpadButtonID);
        }
    }

    void FixedUpdate()
    {
        if (touchpadButtonPressed)
        {
            Vector2 touchpadAxis = vrController.GetAxis(touchpadButtonID);

            Vector3 targetVelocity = HMDTransform.TransformDirection(new Vector3(touchpadAxis.x, 0f, touchpadAxis.y)) * moveSpeed;
            targetVelocity.y = 0f;

            physic.AddForce(targetVelocity - physic.velocity, ForceMode.VelocityChange);
        }
        else
        {
            physic.velocity = new Vector3(0f, physic.velocity.y, 0f);
        }
    }

    void OnCollisionEnter(Collision Other)
    {
        controllerLeft.Pulse(1f, 3500);
        controllerRight.Pulse(1f, 3500);
    }

}
