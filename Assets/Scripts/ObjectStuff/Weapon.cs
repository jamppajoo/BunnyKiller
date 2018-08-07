using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Weapon : MonoBehaviour
{
    //[HideInInspector]
    public bool canBeDestroyed = false;

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

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Environment"))
        {
            canBeDestroyed = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Environment"))
        {
            canBeDestroyed = false;
        }
    }


}
