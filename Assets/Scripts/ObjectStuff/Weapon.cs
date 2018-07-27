using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    [HideInInspector]
    public bool canBeDestroyed = true;

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
        if (canBeDestroyed)
            Destroy(gameObject);
    }
}
