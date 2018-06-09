using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float thrust=10f;
    public Rigidbody rb;
    public float countdown = 0f;
    public GameObject player;
    public bool canJump=false;
    public float explodingPower;
    //public Collider touching;

	private float timeToNextJump;
	private float currentTime;
	private bool jumpRequest;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody>();
	    currentTime = Time.time;
	    timeToNextJump = 1.5f;
	    //touching = this.GetComponent<CapsuleCollider>();
    }
	
	// Update is called once per frame
	void Update () {
       // jump();

		countdown = Time.time - currentTime;
		if (countdown > timeToNextJump)
		{
			jumpRequest = true;
		}
	}

	void FixedUpdate()
	{
		if (jumpRequest)
		{
			
		}
	}
    void jump()
    {
        //print(transform.up);
        countdown -= Time.deltaTime;
        if (countdown <= 0.0f && canJump)
        {
            rb.AddForce(transform.forward * 400f);
            rb.AddForce(transform.up * 50f * (-1));
            countdown = 0.80f + Random.value;
        }
        else if(countdown>-2f)
        {
            if (transform.position.y < 0.3f)
            {
                rb.velocity = Vector3.zero;
                rb.transform.Rotate(-90f, 0f, rb.rotation.z);
            }
            
            Vector3 targetPostition = new Vector3(0,
                                       90,
                                       player.transform.position.z);
            this.transform.LookAt(targetPostition);
        }
        else
        {
            rb.AddForce(transform.forward * 200f);
            rb.AddForce(transform.up * 30f * (-1));
            countdown = 0.80f + Random.value;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        canJump = true;
        float tes = collision.relativeVelocity.magnitude;
        /*if (collision.relativeVelocity.magnitude > explodingPower)
        {
            print("Bum!!!" + tes);
            Explode();
        }
        */
    }

    void OnCollisionExit(Collision collision)
    {
        canJump = false;
    }

    void Explode()
    {
        //        var exp = GetComponent<ParticleSystem>();
        //        exp.Play();
        //Destroy(gameObject, exp.duration);
        //Destroy(gameObject);
    }

}
