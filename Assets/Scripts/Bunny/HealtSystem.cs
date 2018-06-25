using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealtSystem : MonoBehaviour {

    public float health = 100;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void BaseballHit(float power)
    {
        if(power<1) health -= 15f;
        else health -= 34f;
        
        if(health<0)
        {
            if(health<-50)
            {
                Explode();
            }
            else Die();
        }
    }

    public void ScytheHit(float power)
    {
        health -= 1001f;// power;
        if (health < 0)
        {
            if (health < -1000)
            {
                print("Bunny died at ones!!!");
                Die();
            }
            else if (health < -50)
            {
                Explode();
                Die();
            }
            else Die();
        }
    }

    public void Die()
    {
        print("Bunny died!");
        Destroy(gameObject);
    }
    public void Explode()
    {
        print("Bunny Explodes");
    }
}
