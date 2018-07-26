using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {

    public delegate void WaveState();
    public static event WaveState WaveStarted;
    public static event WaveState WaveEnded;
    public static event WaveState WaveOnHold;

    public static EventManager eventManager;

    private void Awake()
    {
        if (eventManager != null)
        {
            Destroy(gameObject);
        }
        else
        {
            eventManager = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void OnWaveStarted()
    {
        WaveStarted();
    }
    public void OnWaveStopped()
    {
        WaveEnded();
    }
    public void OnWaveHold()
    {
        WaveOnHold();
    }

}
