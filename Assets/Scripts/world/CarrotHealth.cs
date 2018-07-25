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

    // Use this for initialization
    void Start ()
    {
        source = GetComponent<AudioSource>();
        carrots = GameObject.Find("carrotsParent");
        gameProgress = GameObject.Find("GameController");
    }
	
	// Update is called once per frame
	void Update () {
        ChangeHealth(Time.deltaTime*eatingBunnyAmount);		
	}

    void ChangeHealth(float amount)
    {
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
        if (other.tag.Equals("Bunny") && other.GetComponent<HealtSystem>().alive)
        {
            //ChangeHealth(1f);
            eatingBunnyAmount++;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Bunny"))
        {
            //ChangeHealth(1f);
            eatingBunnyAmount--;
        }
    }
}


