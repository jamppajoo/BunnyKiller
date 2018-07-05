﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealtSystem : MonoBehaviour
{

	public ParticleSystem bloodParticleSystem;
    public float health = 100;

	public List<GameObject> bluntWeapons;
	public List<GameObject> bladeWeapons;
	private AudioSource audioSource;

	public Rigidbody bunnyRB;
    public bool alive = true;

    private GameObject head;
    private GameObject body;

    private GameObject bunbun;
    private GameObject bodyParts;

    private GameObject gameController;
    private float suicideTime;
    private bool suicideActivated=false;

    // Use this for initialization
    void Start ()
	{
		bloodParticleSystem = GetComponentInChildren<ParticleSystem>();
		bunnyRB = GetComponentInParent<Rigidbody>();
        head = this.gameObject.transform.GetChild(1).GetChild(1).gameObject;
        body = this.gameObject.transform.GetChild(1).GetChild(0).gameObject;
        gameController = GameObject.Find("GameController");

        if (this.gameObject.transform.GetChild(0).gameObject.name.Equals("bunbun")) bunbun = this.gameObject.transform.GetChild(0).gameObject;
        if (this.gameObject.transform.GetChild(2).gameObject.name.Equals("BunnyLimbz"))
        {
            bodyParts = this.gameObject.transform.GetChild(2).gameObject;
            bodyParts.SetActive(false);
        }


        }
	
	// Update is called once per frame
	void Update () {
        if (suicideActivated && suicideTime < 0 && alive)
        {
            health -= 1000;
            Explode();
            Collision hitt = null;
            this.gameObject.GetComponentInChildren<ParticleSpawner>().spillBlood(hitt);
        }
        else if (suicideActivated && alive) suicideTime -= Time.deltaTime;
	}

	public void BaseballHit(float power)
	{
        //Explode();

        if (power < 6) health -= 10f;
        else if(power > 16) health -= 200f;
        else health -= 34f;

		if (health < 0)
		{
			if (health < -50)
			{
				Explode();
			}
			else Die();
		}
	}

	public void ScytheHit(float power)
	{
		health -= power;
		if (health < 0)
		{
            if (alive) addDeath();

            if (health < -100)
			{
                Explode();
			}
			else Die();
		}
	}

    public void Suicide(float time)
    {
        suicideTime = time;
        suicideActivated = true;
    }

    public void addDeath()
    {
        gameController.GetComponent<GameProgression>().addKill();
    }
	public void Die()
    {
        
        this.GetComponent<Rigidbody>().AddForce(transform.up * 5f, ForceMode.Impulse);
        this.GetComponent<Rigidbody>().AddForce(transform.up * 60f);

        alive = false;
        //this makes bunny flat if player hits it after it is dead
        //if (this.transform.localScale.z > 0.02) this.transform.localScale += new Vector3(0.01f, 0.01f, -0.01f); 
    }
    public void Explode()
    {
        alive = false;
        bunbun.SetActive(false);
        bodyParts.SetActive(true);

        if (this.transform.localScale.z>0.02)this.transform.localScale += new Vector3(0.01f, 0.01f, -0.01f);
    }

}
