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
    private bool waveOnHold = true;
    private ObjectCombinerRoom objectCombinerRoom;

    private void OnEnable()
    {
        EventManager.WaveStarted += WaveStarted;
        EventManager.WaveOnHold += WaveEnded;

    }
    private void OnDisable()
    {
        EventManager.WaveStarted -= WaveStarted;
        EventManager.WaveOnHold -= WaveEnded;
        interactableObject.InteractableObjectSnappedToDropZone -= new InteractableObjectEventHandler(ObjectSnappedToDropZone);
        interactableObject.InteractableObjectUnsnappedFromDropZone -= new InteractableObjectEventHandler(ObjectUnSnappedFromDropZone);

        interactableObject.InteractableObjectUngrabbed -= new InteractableObjectEventHandler(ObjectUnGrabbed);
    }
    private void Awake()
    {
        interactableObject = GetComponent<VRTK_InteractableObject>();
        objectCombinerRoom = FindObjectOfType<ObjectCombinerRoom>();
    }
    private void Start()
    {
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
        if (objectCombinerRoom.IsPlayerOnGarage())
            mySnapDropZone = null;
    }
    private void ObjectUnGrabbed(object sender, InteractableObjectEventArgs e)
    {
        if(!objectCombinerRoom.IsPlayerOnGarage())
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
        if (canBeDestroyed)
            DestroyObject();
    }
    private void DestroyObject()
    {
        if(gameObject != null)
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
