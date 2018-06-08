using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HitBunny : MonoBehaviour {

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
            
            if (baseballbat)
            {
                hittedObject = collision.gameObject;
                hittedObject.GetComponent<HealtSystem>().BaseballHit(collision.relativeVelocity.magnitude);
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
            else
            {

            }
            

        }
        
    }

    /*
    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
    */
}
