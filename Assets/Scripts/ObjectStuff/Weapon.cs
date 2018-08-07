using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Weapon : MonoBehaviour
{
    //[HideInInspector]
    public bool canBeDestroyed = false;
    private VRTK_InteractableObject interactableObject;
    private VRTK_SnapDropZone mySnapDropZone;
    private bool waveOnHold = false;

    private void OnEnable()
    {
        EventManager.WaveStarted += WaveStarted;
        EventManager.WaveEnded += WaveEnded;

    }
    private void OnDisable()
    {
        EventManager.WaveStarted -= WaveStarted;
        EventManager.WaveEnded -= DestroyObject;
    }
    private void Awake()
    {
        interactableObject = GetComponent<VRTK_InteractableObject>();
        interactableObject.InteractableObjectSnappedToDropZone += new InteractableObjectEventHandler(ObjectSnappedToDropZone);
        interactableObject.InteractableObjectUnsnappedFromDropZone += new InteractableObjectEventHandler(ObjectUnSnappedFromDropZone);

        interactableObject.InteractableObjectUngrabbed += new InteractableObjectEventHandler(ObjectUnGrabbed);
    }

    private void ObjectSnappedToDropZone(object sender, InteractableObjectEventArgs e)
    {
        mySnapDropZone = e.interactingObject.GetComponent<VRTK_SnapDropZone>();
    }
    private void ObjectUnSnappedFromDropZone(object sender, InteractableObjectEventArgs e)
    {
        if (waveOnHold)
            mySnapDropZone = null;
    }
    private void ObjectUnGrabbed(object sender, InteractableObjectEventArgs e)
    {
        if(!waveOnHold)
        {
            mySnapDropZone.ForceSnap(gameObject);
        }
    }
        private void WaveStarted()
    {
        waveOnHold = false;
    }
    private void WaveEnded()
    {
        waveOnHold = true;
        DestroyObject();
    }
    private void DestroyObject()
    {
        if (canBeDestroyed)
            Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Environment"))
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
