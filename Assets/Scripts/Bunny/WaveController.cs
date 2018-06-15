using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{

    public int waveLength = 60;

    private float timer = 0;
    public bool waveStarted = false;
    private ObjectCombinerRoom objectCombinerRoom;

    private void Start()
    {
        objectCombinerRoom = FindObjectOfType<ObjectCombinerRoom>();
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
        waveStarted = true;
    }
    private void WaveEnded()
    {
        timer = 0;
        waveStarted = false;
        objectCombinerRoom.OpenDoors();
    }

}
