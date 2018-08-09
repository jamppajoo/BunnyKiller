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
    private GameObject carrotParent;
	public GameObject targetCarrot;
    private int carrotCount;

	private float timeToNextJump;
    private float timeToNextTarget;
	private float timeFromLastJump;
    private float timeFromTargetChange;
	private bool jumpRequest;
	public float jumpMultiplier;
	public float fallMultiplier;
    private float bunnySpeed;
    private bool targetRandomized;

	public float gravityScale = 1.0f;
	public static float globalGravity = -9.81f;
    //private bool 
	
	void Start () {

        //Bunny will randomly choose which carrot it will eat
        carrotParent = GameObject.Find("carrotsParent");
        carrotCount = carrotParent.transform.childCount;

        //if there isn't any carrots, bunny will target player
        if (carrotCount == 0)
        {
            targetCarrot = GameObject.Find("Camera");
            if (targetCarrot == null) targetCarrot = GameObject.Find("Camera (head)");
        }
        else targetCarrot = carrotParent.transform.GetChild(Random.Range(0, carrotCount)).gameObject;

        timeFromLastJump = Time.time;
        timeFromTargetChange = Time.time;
	    timeToNextJump = 2.5f;
        timeToNextTarget = 30f;
	    jumpRequest = false;
        //jumpMultiplier = 2.0f;
        jumpMultiplier = 2.5f;
        fallMultiplier = 1.5f;
        bunnySpeed = Random.value;
    }
	
	void OnEnable()
	{
		rb = GetComponent<Rigidbody>();
		rb.useGravity = false;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.DrawRay(transform.position, Vector3.forward, Color.red);
		Debug.DrawRay(transform.position, Vector3.up, Color.cyan);

		if (Time.time - timeFromLastJump > timeToNextJump+bunnySpeed)
		{
			jumpRequest = true;
            timeFromLastJump = Time.time;
		}

        if(Time.time - timeFromTargetChange>timeToNextTarget||targetCarrot==null)
        {
            carrotCount = carrotParent.transform.childCount;
            if (carrotCount == 0)
            {
                targetCarrot = GameObject.Find("Camera");
                if(targetCarrot==null) targetCarrot = GameObject.Find("Camera (head)");
            }
            else targetCarrot = carrotParent.transform.GetChild(Random.Range(0, carrotCount)).gameObject;
            timeFromTargetChange = Time.time;
        }

        Debug.DrawRay(targetCarrot.transform.position, Vector3.up, Color.blue);
    }

	void FixedUpdate()
	{
		Vector3 gravity = globalGravity * gravityScale * Vector3.up;
        rb.AddForce(gravity, ForceMode.Acceleration);

		if (jumpRequest&& GetComponent<HealtSystem>().alive)
		{
            //randomExtra is a number that makes jumps more random every jump is 75% - 125% of normal jump
            float randomExtra = Random.Range(0.75f, 1.25f);
            rb.AddForce(transform.up * 5f* randomExtra * jumpMultiplier, ForceMode.Impulse);
            rb.AddForce(transform.forward * 1.25f*randomExtra, ForceMode.Impulse);

            jumpRequest = false;
            targetRandomized = false;
            jumpMultiplier = 1.0f;
		}

        //if bunny is low enough, it turns towards target
        else if (transform.position.y < 0.2f && transform.position.y > -0.2 && GetComponent<HealtSystem>().alive && !targetRandomized) 
        {
            if(targetCarrot==null)
            {
                carrotCount = carrotParent.transform.childCount;
                if (carrotCount == 0)
                {
                    targetCarrot = GameObject.Find("Camera");
                    if (targetCarrot == null) targetCarrot = GameObject.Find("Camera (head)");
                }
                else targetCarrot = carrotParent.transform.GetChild(Random.Range(0, carrotCount)).gameObject;
            }

            Vector3 targetPostition = new Vector3(targetCarrot.transform.position.x+(Random.value*2-1),
                                       0,
                                       targetCarrot.transform.position.z);

            this.transform.LookAt(targetPostition);
            //          this.transform.rotation=new Vector3(0f,targetPostition.y,0f);
            /*this.transform.eulerAngles = new Vector3(
                0f,
                this.transform.eulerAngles.y,
                0f);
            */
            //this.transform.eulerAngles = new Quaternion(30, transform.eulerAngles.y, transform.eulerAngles.z);
            transform.eulerAngles = new Vector3(0f, this.transform.eulerAngles.y, 0f);

            targetRandomized = true;
            //jumpRequest = true;
        }
        else if (GetComponent<HealtSystem>().alive == false)
        {
            //if (GetComponent<HealtSystem>().alive) { 
                Vector3 targetPostition = new Vector3(0f,
                                                     -1000f,
                                                      0);
                this.transform.LookAt(targetPostition);
            //}
        }
        //turn rabbit to normal rotation, only x and z, y still towards to target
        transform.eulerAngles = new Vector3(0f, this.transform.eulerAngles.y, 0f);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    public void HitBunny(Vector3 direction, float force)
    {
        rb.AddForce(direction*force, ForceMode.Impulse);
//        print("FORCE ADDED " + direction * force);
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
