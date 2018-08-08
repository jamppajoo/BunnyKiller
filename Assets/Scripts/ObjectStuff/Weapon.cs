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
    }
    private void Start()
    {

        //interactableObject.SetInteractableObjectEvent(gameObject);
        interactableObject.InteractableObjectSnappedToDropZone += new InteractableObjectEventHandler(ObjectSnappedToDropZone);
        interactableObject.InteractableObjectUnsnappedFromDropZone += new InteractableObjectEventHandler(ObjectUnSnappedFromDropZone);

        interactableObject.InteractableObjectUngrabbed += new InteractableObjectEventHandler(ObjectUnGrabbed);
    }



    private void ObjectSnappedToDropZone(object sender, InteractableObjectEventArgs e)
    {
        print("ASDOKPASDOPK" + e.interactingObject);
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
        print("Wave edned");
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
