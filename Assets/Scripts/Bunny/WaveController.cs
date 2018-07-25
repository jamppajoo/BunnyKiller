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


    private void Start()
    {
        gameController = GameObject.Find("GameController");
        timeCountPanel = GameObject.Find("timeText");
        doorCloser = GameObject.Find("Huone_lattia");
        enemyParent = GameObject.Find("Enemies");

    }
    private void Update()
    {
        if (waveStarted)
        {
            if (timer < waveLength)
            {
                timer += Time.deltaTime;
                timeCountPanel.GetComponent<Text>().text = "" + (Mathf.Round(100*(waveLength-timer))/100);
            }
            else
            {
                WaveEnded();
                timeCountPanel.GetComponent<Text>().text = "0";
            }


        }
        else timeCountPanel.GetComponent<Text>().text = "0";
    }
    public void StartWave()
    {
        timer = 0;
        gameController.GetComponent<GameProgression>().addWave();
        waveNumber++;
        GetComponent<BunnyMaker>().amount = 10 + waveNumber;
        GetComponent<BunnyMaker>().health = 100 + waveNumber*10;
        GetComponent<BunnyMaker>().startWave();
        waveStarted = true;
        GetComponent<BunnyMaker>().maded = 0;
        
    }
    public void WaveEnded()
    {
//        print("Wave Ended");
        timer = 0;
        timeCountPanel.GetComponent<Text>().text = "0";
        waveStarted = false;
        doorCloser.transform.GetComponent<ObjectCombinerRoom>().OpenDoors();

        //kill all still alive bunnies. Kill them 4 by second
        HealtSystem[] allChildren = enemyParent.GetComponentsInChildren<HealtSystem>();
        float i = 0f;
        foreach (HealtSystem child in allChildren)
        {
            child.Suicide(i/4);
            i++;
        }
    }

}
