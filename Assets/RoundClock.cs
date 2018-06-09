using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundClock : MonoBehaviour {

    private bool roundStart = false;
    public float timeLeft;

    void OnTriggerStay(Collider Player)
    {
        Debug.Log("Round start");
        roundStart = true;
    }

        void Update () {
        if (roundStart == true)
        {
            timeLeft -= Time.time;
        }
        if (timeLeft == 0f)
        {
            Debug.Log("round is over");
            return;
        }
    }
}
