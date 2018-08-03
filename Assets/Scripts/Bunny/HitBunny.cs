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

    public float weaponMass;
    public float weaponKillMultipler;
    private Vector3 lastPosition;


    // Use this for initialization
    void Start () {
        lastPosition = transform.position;
		
	}
	
	// Update is called once per frame
	void Update () {
        lastPosition = transform.position;
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
            collision.gameObject.GetComponentInChildren<ParticleSpawner>().spillBlood(collision);
            if (baseballbat)
            {

                Rigidbody body;
                body = GetComponent<Rigidbody>();
                float hitPower= collision.relativeVelocity.magnitude * body.velocity.magnitude * body.mass;

                hitPower = Vector3.Dot(collision.contacts[0].normal, collision.relativeVelocity);

                hittedObject = collision.gameObject;
                hittedObject.GetComponent<HealtSystem>().BaseballHit(hitPower);
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
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bunny")
        {
            other.GetComponent<Movement>().HitBunny((lastPosition-transform.position), Vector3.Distance(lastPosition, transform.position));
        }
    }
}
