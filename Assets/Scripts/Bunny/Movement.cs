﻿using System.Collections;
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
    private float bunnySpeed;

	public float gravityScale = 1.0f;
	public static float globalGravity = -9.81f;
	
	void Start () {
		player = GameObject.Find("Carrot");
	    currentTime = Time.time;
	    timeToNextJump = 2.5f;
	    jumpRequest = false;
	    jumpMultiplier = 2.0f;
	    fallMultiplier = 1.5f;
        bunnySpeed = Random.value;
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

		if (Time.time - currentTime > timeToNextJump+bunnySpeed)
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

		if (jumpRequest&& GetComponent<HealtSystem>().alive)
		{
			rb.AddForce(transform.up * 5f, ForceMode.Impulse);
			//rb.velocity += -transform.forward * Physics.gravity.y * (jumpMultiplier - 1) * Time.fixedDeltaTime;
			rb.AddForce(transform.up * 60f);

			jumpRequest = false;
		}
        
		if (transform.position.y < 0.2f&& transform.position.y > -0.2 && GetComponent<HealtSystem>().alive) //if bunny is low enough, gravity is normal and it disappears faster
		{
			//rb.velocity = Vector3.zero;
			//rb.transform.Rotate(-90f, 0f, rb.rotation.z, Space.World);
                    Vector3 targetPostition = new Vector3(player.transform.position.x,
                                               0,
                                               0);

                    this.transform.LookAt(targetPostition);

            //jumpRequest = true;
        }
        else if(GetComponent<HealtSystem>().alive==false)
        {/*
            Vector3 targetPostition = new Vector3(-90,
                                               -90,
                                               -90);

            this.transform.LookAt(targetPostition);*/
         //rb.transform.Rotate(-90f, 0f, rb.rotation.z);
         ///rb.transform.rotation = Quaternion.Euler(90, rb.transform.rotation.y, rb.transform.rotation.z);
            //rb.transform.eulerAngles = new Vector3(90.0f, rb.rotation.y, rb.rotation.z);
            //rb.transform.rotation = (-90f, 0f, rb.rotation.z);
            Vector3 targetPostition = new Vector3(0f,
                                               -1000f,
                                               0);

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
