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

    private HolsterController holsterController;

    private bool objectBeingTouched = false;
    private bool objectBeingGrabbed = false;

    private bool canBeHolstered = false;


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

        interactableObject.InteractableObjectEnteredSnapDropZone -= new InteractableObjectEventHandler(ObjectEnteredDropZone);
        interactableObject.InteractableObjectExitedSnapDropZone -= new InteractableObjectEventHandler(ObjectExitedDropZone);

        interactableObject.InteractableObjectUngrabbed -= new InteractableObjectEventHandler(ObjectUnGrabbed);
        interactableObject.InteractableObjectGrabbed -= new InteractableObjectEventHandler(ObjectGrabbed);

        interactableObject.InteractableObjectTouched -= new InteractableObjectEventHandler(ObjectTouched);
        interactableObject.InteractableObjectUntouched -= new InteractableObjectEventHandler(ObjectUnTouched);


    }
    private void Awake()
    {
        interactableObject = GetComponent<VRTK_InteractableObject>();
        objectCombinerRoom = FindObjectOfType<ObjectCombinerRoom>();
        holsterController = FindObjectOfType<HolsterController>();
    }
    private void Start()
    {
        interactableObject.InteractableObjectSnappedToDropZone += new InteractableObjectEventHandler(ObjectSnappedToDropZone);
        interactableObject.InteractableObjectUnsnappedFromDropZone += new InteractableObjectEventHandler(ObjectUnSnappedFromDropZone);

        interactableObject.InteractableObjectEnteredSnapDropZone += new InteractableObjectEventHandler(ObjectEnteredDropZone);
        interactableObject.InteractableObjectExitedSnapDropZone += new InteractableObjectEventHandler(ObjectExitedDropZone);

        interactableObject.InteractableObjectUngrabbed += new InteractableObjectEventHandler(ObjectUnGrabbed);
        interactableObject.InteractableObjectGrabbed += new InteractableObjectEventHandler(ObjectGrabbed);

        interactableObject.InteractableObjectTouched += new InteractableObjectEventHandler(ObjectTouched);
        interactableObject.InteractableObjectUntouched += new InteractableObjectEventHandler(ObjectUnTouched);

    }

    private void ObjectEnteredDropZone(object sender, InteractableObjectEventArgs e)
    {
    }
    private void ObjectExitedDropZone(object sender, InteractableObjectEventArgs e)
    {
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
        if (!objectCombinerRoom.IsPlayerOnGarage())
        {
            canBeHolstered = true;
            //HolsterWeapon();
            StartCoroutine(HolsterWeapon());
        }
    }
    private void ObjectGrabbed(object sender, InteractableObjectEventArgs e)
    {
        canBeHolstered = false;
    }

    private void ObjectTouched(object sender, InteractableObjectEventArgs e)
    {
    }
    private void ObjectUnTouched(object sender, InteractableObjectEventArgs e)
    {
    }

    private IEnumerator HolsterWeapon()
    {
        yield return new WaitForEndOfFrame();
        print("ASD1 ");
        if (canBeHolstered)
        {
            print("ASD2 ");
            if (mySnapDropZone == null)
                mySnapDropZone = holsterController.GetEmptyDropZone();

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
        if (gameObject != null)
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
