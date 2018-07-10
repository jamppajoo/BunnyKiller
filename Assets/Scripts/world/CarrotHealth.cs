using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotHealth : MonoBehaviour {

    public float health = 100f;
    private GameObject carrots;
    private GameObject gameProgress;

	// Use this for initialization
	void Start ()
    {
        carrots = GameObject.Find("carrotsParent");
        gameProgress = GameObject.Find("GameController");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void changeHealth(float amount)
    {
        health -= amount;
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
        if (other.tag.Equals("Bunny")) changeHealth(1f);
    }
}
