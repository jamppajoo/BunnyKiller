using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameProgression : MonoBehaviour {

    public int wave;
    public int kills;
    private GameObject killCountPanel;

	// Use this for initialization
	void Start () {
        killCountPanel = GameObject.Find("killCountText");
        updateScoreBoard();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void addWave()
    {
        wave++;
        updateScoreBoard();
    }

    public void addKill()
    {
        kills++;
        updateScoreBoard();
    }

    public void reset()
    {
        wave = 0;
        kills = 0;
        updateScoreBoard();
    }

    public void updateScoreBoard()
    {
        killCountPanel.GetComponent<Text>().text = "\nKills "+kills + "\nWave "+wave;
    }
}
