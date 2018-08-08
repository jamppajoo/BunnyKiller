﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveController : MonoBehaviour
{

    public int waveLength = 60;
    public int waveNumber = 0;

    private float timer = 0;
    public bool waveStarted = false;
    private ObjectCombinerRoom objectCombinerRoom;

    private GameObject gameController;
    private GameObject timeCountPanel;
    private GameObject doorCloser;
    private GameObject enemyParent;

    private TeleportArea teleportArea;

    private void Start()
    {
        gameController = GameObject.Find("GameController");
        timeCountPanel = GameObject.Find("timeText");
        doorCloser = GameObject.Find("Huone_lattia");
        enemyParent = GameObject.Find("Enemies");
        teleportArea = FindObjectOfType<TeleportArea>();
        EventManager.eventManager.OnWaveHold();

    }
    private void Update()
    {
        if (waveStarted)
        {
            if (timer < waveLength)
            {
                timer += Time.deltaTime;
                timeCountPanel.GetComponent<Text>().text = "" + (Mathf.Round(100*(waveLength-timer))/100);
                EventManager.eventManager.OnWaveStarted();
            }

            else
            {
                WaveEnded();
                timeCountPanel.GetComponent<Text>().text = "0";
                EventManager.eventManager.OnWaveStopped();
                EventManager.eventManager.OnWaveHold();
            }
        }
        else timeCountPanel.GetComponent<Text>().text = "0";
    }
    public void StartWave()
    {
        gameController.GetComponent<GameProgression>().addWave();
        waveNumber++;
        GetComponent<BunnyMaker>().amount = 10 + waveNumber;
        GetComponent<BunnyMaker>().health = 100 + waveNumber*10;
        GetComponent<BunnyMaker>().startWave();
        waveStarted = true;
        GetComponent<BunnyMaker>().maded = 0;
        
    }
    private void WaveEnded()
    {
//        print("Wave Ended");
        timer = 0;
        waveStarted = false;
        doorCloser.transform.GetComponent<ObjectCombinerRoom>().OpenDoors();

        HealtSystem[] allChildren = enemyParent.GetComponentsInChildren<HealtSystem>();
        float i = 0f;
        /*
        for(int j=0; j< allChildren.Length; j++)
        {
            allChildren[j].Suicide(i / 2);
            i++;
        }*/
        foreach (HealtSystem child in allChildren)
        {
            child.Suicide(i/4);
            i++;
        }
    }

}
