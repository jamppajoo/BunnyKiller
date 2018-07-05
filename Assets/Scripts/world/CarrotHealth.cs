using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotHealth : MonoBehaviour {

    public float health = 100f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void changeHealth(float amount)
    {
        health -= amount;
        if(health<0) Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Bunny")) changeHealth(1f);
    }

}
