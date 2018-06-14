using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour {
	//public float countdown = 0f;
	//public float thrust=10f;
	//public bool canJump=false;
	//public float explodingPower;
	//public Collider touching;
	public Rigidbody rb;
	public GameObject player;

	private float timeToNextJump;
	private float currentTime;
	private bool jumpRequest;
	public float jumpMultiplier;
	public float fallMultiplier;

	public float gravityScale = 1.0f;
	public static float globalGravity = -9.81f;
	
	void Start () {
		player = GameObject.Find("Player");
	    currentTime = Time.time;
	    timeToNextJump = 2.5f;
	    jumpRequest = false;
	    jumpMultiplier = 2.5f;
	    fallMultiplier = 1.5f;
	    //touching = this.GetComponent<CapsuleCollider>();
    }
	
	void OnEnable()
	{
		rb = GetComponent<Rigidbody>();
		rb.useGravity = false;
	}
	
	// Update is called once per frame
	void Update () {
		//jump();

		Debug.DrawRay(transform.position, Vector3.forward, Color.red);
		Debug.DrawRay(transform.position, Vector3.up, Color.cyan);

		if (Time.time - currentTime > timeToNextJump)
		{
			//Debug.Log("DINGDING JUMPENING");
			jumpRequest = true;
			currentTime = Time.time;
		}
	}

	void FixedUpdate()
	{
		Vector3 gravity = globalGravity * gravityScale * Vector3.up;
		rb.AddForce(gravity, ForceMode.Acceleration);

		if (jumpRequest)
		{
			rb.AddForce(Vector3.up * 5f, ForceMode.Impulse);
			//rb.velocity += Vector3.forward * Physics.gravity.y * (jumpMultiplier - 1) * Time.fixedDeltaTime;
			rb.AddForce(transform.up * 60f);


			jumpRequest = false;
		}
		if (transform.position.y < 0.4f&& transform.position.y > -0.2) //if bunny is low enough, gravity is normal and it disappears faster
		{
			//rb.velocity = Vector3.zero;
			rb.transform.Rotate(-90f, 0f, rb.rotation.z, Space.World);
                    Vector3 targetPostition = new Vector3(0,
                                               0,
                                               player.transform.position.z);
                    this.transform.LookAt(targetPostition);
        }

    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    //void jump()
    //{
    //    //print(transform.up);
    //    countdown -= Time.deltaTime;
    //    if (countdown <= 0.0f && canJump)
    //    {
    //        rb.AddForce(transform.forward * 400f);
    //        rb.AddForce(transform.up * 50f * (-1));
    //        countdown = 0.80f + Random.value;
    //    }
    //    else if(countdown>-2f)
    //    {
    //        if (transform.position.y < 0.3f)
    //        {
    //            rb.velocity = Vector3.zero;
    //            rb.transform.Rotate(-90f, 0f, rb.rotation.z);
    //        }

    //        Vector3 targetPostition = new Vector3(0,
    //                                   90,
    //                                   player.transform.position.z);
    //        this.transform.LookAt(targetPostition);
    //    }
    //    else
    //    {
    //        rb.AddForce(transform.forward * 200f);
    //        rb.AddForce(transform.up * 30f * (-1));
    //        countdown = 0.80f + Random.value;
    //    }
    //}

    //void OnCollisionEnter(Collision collision)
    //{
    //    canJump = true;
    //    float tes = collision.relativeVelocity.magnitude;
    //    /*if (collision.relativeVelocity.magnitude > explodingPower)
    //    {
    //        print("Bum!!!" + tes);
    //        Explode();
    //    }
    //    */
    //}

    //void OnCollisionExit(Collision collision)
    //{
    //    canJump = false;
    //}

    //void Explode()
    //{
    //    //        var exp = GetComponent<ParticleSystem>();
    //    //        exp.Play();
    //    //Destroy(gameObject, exp.duration);
    //    //Destroy(gameObject);
    //}

}
