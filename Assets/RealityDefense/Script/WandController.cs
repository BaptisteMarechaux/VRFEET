using UnityEngine;
using System.Collections;
using System;

public class WandController : MonoBehaviour
{
    private SteamVR_TrackedObject trackedObj;
    SteamVR_Controller.Device device;

    private GameObject pickup;
    private bool onLeg = false;

    // Use this for initialization
    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        device = SteamVR_Controller.Input((int)trackedObj.index);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Leg")
        {
           // onLeg = true;
        }
    }

    private void OnTriggerStay(Collider collider)
    {
        pickup = collider.gameObject;
        if (device.GetPress(SteamVR_Controller.ButtonMask.Trigger) && pickup != null)
        {
            pickup.transform.parent = this.transform;
            pickup.GetComponent<Rigidbody>().isKinematic = true;
        }
        if (device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger) && pickup != null)
        {
            if (!onLeg)
            {
                pickup.transform.parent = null;
                pickup.GetComponent<Rigidbody>().isKinematic = false;

                tossObject(collider.attachedRigidbody);
            }
            else
            {
                pickup.transform.parent = collider.gameObject.transform;
            }

        }
    }

    void tossObject(Rigidbody rigidbody)
    {
        /*Transform origin = trackedObj.origin ? trackedObj.origin : trackedObj.transform.parent;
        if (origin != null) {
        }*/

        rigidbody.velocity = device.velocity;
        rigidbody.angularVelocity = device.angularVelocity;
    }


    private void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Leg")
        {
            onLeg = false;
        }
        else
        {
            pickup.transform.parent = null;
            pickup.GetComponent<Rigidbody>().isKinematic = false;
        }

    }
}