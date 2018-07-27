using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CarrotHealth : MonoBehaviour {

    public float health = 100f;
    private GameObject carrots;
    private GameObject gameProgress;
    private int eatingBunnyAmount = 0;

    public AudioClip eatSound;
    private AudioSource source;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;
    private bool bunnyOnCarrot = false;

    // Use this for initialization
    void Start ()
    {
        source = GetComponent<AudioSource>();
        carrots = GameObject.Find("carrotsParent");
        gameProgress = GameObject.Find("GameController");
    }
	
	// Update is called once per frame
	void Update () {
        if(bunnyOnCarrot)ChangeHealth(Time.deltaTime*eatingBunnyAmount);
	}

    void ChangeHealth(float amount)
    {
        bunnyOnCarrot = false;
        health -= amount;
        if(amount>0)
        {
            if (!source.isPlaying)
            {
                float vol = Random.Range(volLowRange, volHighRange);
                source.PlayOneShot(eatSound, vol);
            }
        }
        if (health < 0)
        {
            Destroy(gameObject);
            if (carrots.transform.childCount < 2)
            {
                gameProgress.GetComponent<GameProgression>().playerDied();
            }
        }
    }

    
    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Bunny") && other.GetComponentInParent<HealtSystem>().alive)
        {
            eatingBunnyAmount++;
            bunnyOnCarrot = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Bunny") && other.GetComponentInParent<HealtSystem>().alive)
        {
            eatingBunnyAmount--;
            if (eatingBunnyAmount < 0) eatingBunnyAmount = 0;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals("Bunny") && other.GetComponentInParent<HealtSystem>().alive)
        {
            bunnyOnCarrot = true;
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Bunny") && collision.gameObject.GetComponent<HealtSystem>().alive)
        {
            eatingBunnyAmount++;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Bunny") && collision.gameObject.GetComponent<HealtSystem>().alive)
        {
            eatingBunnyAmount--;
            if (eatingBunnyAmount < 0) eatingBunnyAmount = 0;
        }
    }


}


