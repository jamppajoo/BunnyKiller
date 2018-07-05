using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{

    public int waveLength = 60;
    public int waveNumber = 0;

    private float timer = 0;
    public bool waveStarted = false;
    private ObjectCombinerRoom objectCombinerRoom;

    private GameObject gameController;


    private void Start()
    {
        gameController = GameObject.Find("GameController");

    }
    private void Update()
    {
        if (waveStarted)
        {
            if (timer < waveLength)
                timer += Time.deltaTime;
            else
            {
                WaveEnded();
            }
        }
    }
    public void StartWave()
    {
        gameController.GetComponent<GameProgression>().addWave();
        waveNumber++;
        GetComponent<BunnyMaker>().amount = 10 + waveNumber;
        GetComponent<BunnyMaker>().health = 100 + waveNumber*10;
        waveStarted = true;
        GetComponent<BunnyMaker>().maded = 0;
    }
    private void WaveEnded()
    {
        timer = 0;
        waveStarted = false;
        objectCombinerRoom.OpenDoors();
    }

}
