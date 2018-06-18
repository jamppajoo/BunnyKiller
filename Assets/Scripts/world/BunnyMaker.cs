using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyMaker : MonoBehaviour {

    public GameObject bunnyObject;
    public int amount;
    private int maded=0;
    private Time time;

    // Use this for initialization
    void Start () {
        //Instantiate(bunnyObject, new Vector3(5.58f,0.405f,4.37f), Quaternion.identity);
        Instantiate(bunnyObject, new Vector3(-20f, 0.405f, 2.94f), Quaternion.identity);
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.time > maded * 1&& maded<amount)
        {
            //Instantiate(bunnyObject, new Vector3(8.08f, 0.405f, (8.31f- Random.value*16f)), Quaternion.identity);
            Instantiate(bunnyObject, new Vector3(-20f, 0.405f, (2.94f - Random.value * 16f)), Quaternion.identity);
            maded++;
        }

    }
}
