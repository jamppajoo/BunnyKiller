using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class HitBunny : MonoBehaviour {

    private SteamVR_TrackedObject trackedObj;
    SteamVR_Controller.Device device;

    private float impactMagnifier = 120f;
    private float collisionForce = 0f;
    private float maxCollisionForce = 4000f;
    private VRTK_ControllerReference controllerReference;

    public bool baseballbat = false;
    public bool scythe = false;

    private GameObject hittedObject;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision)
    {
        controllerReference = VRTK_ControllerReference.GetControllerReference(this.gameObject);

        float tes = collision.relativeVelocity.magnitude;

        if (VRTK_ControllerReference.IsValid(controllerReference))
        {
            collisionForce = VRTK_DeviceFinder.GetControllerVelocity(controllerReference).magnitude * impactMagnifier*5;
            var hapticStrength = collisionForce / maxCollisionForce;
            VRTK_ControllerHaptics.TriggerHapticPulse(controllerReference, hapticStrength, 0.5f, 0.01f);
        }
        else
        {
            collisionForce = collision.relativeVelocity.magnitude * impactMagnifier*5;
        }

        if (collision.gameObject.tag == "Bunny")
        {
            //            SteamVR_Controller.Input([the index of the controller you want to vibrate]).TriggerHapticPulse([length in microseconds as ushort]);
            //SteamVR_Controller.Input(1).TriggerHapticPulse(250);
/*            trackedObj = GetComponent<SteamVR_TrackedObject>();
            device = SteamVR_Controller.Input((int)trackedObj.index);
            rumbleController();
            */

//            SteamVR_Controller.Input((int)trackedObj.index).TriggerHapticPulse(500);
            collision.gameObject.GetComponentInChildren<ParticleSpawner>().spillBlood(collision);
            if (baseballbat)
            {

                Rigidbody body;
                body = GetComponent<Rigidbody>();
                float hitPower= collision.relativeVelocity.magnitude * body.velocity.magnitude * body.mass;

                hitPower = Vector3.Dot(collision.contacts[0].normal, collision.relativeVelocity);

                hittedObject = collision.gameObject;
                hittedObject.GetComponent<HealtSystem>().BaseballHit(hitPower);
                if(hitPower>10)print(hitPower);

            }
            if (scythe)
            {
                foreach (ContactPoint contact in collision.contacts)
                {
                    if(contact.thisCollider.name.Equals("blade"))
                    {
                        hittedObject = collision.gameObject;
                        hittedObject.GetComponent<HealtSystem>().ScytheHit(collision.relativeVelocity.magnitude);
                    }
                    //                    print(contact.thisCollider.name + " hit " + contact.otherCollider.name);
                    //                    Debug.DrawRay(contact.point, contact.normal, Color.white);
                }
            }
        }
    }

    /*
    public float CollisionForce()
    {
        return collisionForce;
    }

    public void Grabbed(VRTK_InteractGrab grabbingObject)
    {
        base.Grabbed(grabbingObject);
        controllerReference = VRTK_ControllerReference.GetControllerReference(grabbingObject.controllerEvents.gameObject);
    }

    public override void Ungrabbed(VRTK_InteractGrab previousGrabbingObject)
    {
        base.Ungrabbed(previousGrabbingObject);
        controllerReference = null;
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        controllerReference = null;
        interactableRigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (VRTK_ControllerReference.IsValid(controllerReference) && IsGrabbed())
        {
            collisionForce = VRTK_DeviceFinder.GetControllerVelocity(controllerReference).magnitude * impactMagnifier;
            var hapticStrength = collisionForce / maxCollisionForce;
            VRTK_ControllerHaptics.TriggerHapticPulse(controllerReference, hapticStrength, 0.5f, 0.01f);
        }
        else
        {
            collisionForce = collision.relativeVelocity.magnitude * impactMagnifier;
        }
    }
    */

}
