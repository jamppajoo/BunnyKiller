using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameProgression : MonoBehaviour {

    public int wave;
    public int kills;
    public float score;
    private GameObject killCountPanel;
    private GameObject statsPanel;
    private GameObject carrotParent;

	// Use this for initialization
	void Start () {
        killCountPanel = GameObject.Find("killCountText");
        updateScoreBoard();
        statsPanel = GameObject.Find("gameStatText");
        carrotParent = GameObject.Find("carrotsParent");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void addWave()
    {
        wave++;

        //Score is amount of healt of all carrots
        CarrotHealth[] allChildren = carrotParent.GetComponentsInChildren<CarrotHealth>();
        foreach (CarrotHealth child in allChildren)
        {
            score += child.health;
        }
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
        score = 0.0f;
        updateScoreBoard();
        //respawn carrots
        //teleport player in front of score board
    }

    public void updateScoreBoard()
    {
        killCountPanel.GetComponent<Text>().text = "\nKills "+kills + "\nWave "+wave + "\nScore " + Mathf.Round(score);
    }

    public void playerDied()
    {
        statsPanel.GetComponent<Text>().text = "Latest Score"+
                                                    "\nYou killed "+kills+ " bunnies"+
                                                    "\nYou survived "+wave+ " waves"+
                                                    "\nYour score " + Mathf.Round(score) + " points"
                                                    ;
        reset();
    }
}
