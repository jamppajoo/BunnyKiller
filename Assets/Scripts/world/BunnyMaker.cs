using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyMaker : MonoBehaviour {

    public GameObject bunnyObject;
    public int amount;
    public int health=100;
    public int maded=0;
    public float bunniesPerSecond=1.0f;
    private Time time;
    private GameObject enemiesParent;
    private GameObject wavecontroller;
    private float timeMaded;
    private float waveStarted;

    // Use this for initialization
    void Start()
    {
        enemiesParent = GameObject.Find("Enemies");
        wavecontroller = GameObject.Find("WaveController");
        waveStarted = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.time-waveStarted > maded/bunniesPerSecond && maded<amount && wavecontroller.GetComponent<WaveController>().waveStarted)
        {
            //Instantiate(bunnyObject, new Vector3(8.08f, 0.405f, (8.31f- Random.value*16f)), Quaternion.identity);
            //Instantiate(bunnyObject, new Vector3(-20f, 0.405f, (2.94f - Random.value * 16f)), Quaternion.identity);
            GameObject bunny = Instantiate(bunnyObject, new Vector3(-9f, 0.405f, (3f - Random.value * 6f)), Quaternion.identity);
            bunny.GetComponent<HealtSystem>().health = health;
            bunny.transform.parent = enemiesParent.transform;
            maded++;
        }
    }

    public void startWave()
    {
        waveStarted = Time.time;
    }
}
