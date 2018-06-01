using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float thrust=10f;
    public Rigidbody rb;
    public float countdown = 6.0f;
    public GameObject player;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        jump();        
    }

    void jump()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0.0f)
        {
//            rb.AddForce((player.transform.position - transform.position + new Vector3((Random.value- 0.5f) *5, 0, (Random.value-0.5f)*5)) * thrust);

            //rb.AddForce(new Vector3(0f, 100f, 50f));// transform.up * thrust*10f);
            rb.AddForce(transform.forward * 200f);

            rb.AddForce(transform.up * 100f * (-1));
            countdown = 0.40f+ Random.value;
        }
    }
}
