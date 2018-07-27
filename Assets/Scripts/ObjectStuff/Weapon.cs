using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {


    private void OnEnable()
    {
        EventManager.WaveEnded += DestroyObject;
    }
    private void OnDisable()
    {
        EventManager.WaveEnded -= DestroyObject;
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}
