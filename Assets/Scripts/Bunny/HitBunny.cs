using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HitBunny : MonoBehaviour {

    private SteamVR_TrackedObject trackedObj;
    SteamVR_Controller.Device device;

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
        float tes = collision.relativeVelocity.magnitude;

        if (collision.gameObject.tag == "Bunny")
        {
            //            SteamVR_Controller.Input([the index of the controller you want to vibrate]).TriggerHapticPulse([length in microseconds as ushort]);
            //SteamVR_Controller.Input(1).TriggerHapticPulse(250);
            trackedObj = GetComponent<SteamVR_TrackedObject>();
            device = SteamVR_Controller.Input((int)trackedObj.index);
            rumbleController();

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
    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
    */
    void rumbleController()
    {
        StartCoroutine(LongVibration(1, 3999));
    }


    IEnumerator LongVibration(float length, ushort strength)
    {
        for (float i = 0; i < length; i += Time.deltaTime)
        {
            device.TriggerHapticPulse(strength);
            yield return null; //every single frame for the duration of "length" you will vibrate at "strength" amount
        }
    }

}
