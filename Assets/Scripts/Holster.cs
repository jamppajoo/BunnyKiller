using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Holster : MonoBehaviour {


    private GameObject weapon;

    private VRTK_SnapDropZone dropZone;

    private void OnEnable()
    {
        EventManager.WaveStarted += DisableChangeWeapon;
        EventManager.WaveOnHold += EnableChangeWeapon;
    }
    private void OnDisable()
    {
        EventManager.WaveStarted -= DisableChangeWeapon;
        EventManager.WaveOnHold -= EnableChangeWeapon;

    }

    private void Start()
    {
        dropZone = GetComponent<VRTK_SnapDropZone>();

        dropZone.ObjectSnappedToDropZone += new SnapDropZoneEventHandler(ObjectSnappedToDropZone);
        dropZone.ObjectUnsnappedFromDropZone += new SnapDropZoneEventHandler(ObjectUnSnappedFromDropZone);
        EnableChangeWeapon();
    }


    private void ObjectSnappedToDropZone(object sender, SnapDropZoneEventArgs e)
    {
        weapon = e.snappedObject;
    }
    private void ObjectUnSnappedFromDropZone(object sender, SnapDropZoneEventArgs e)
    {
        weapon = null;
    }

    private void EnableChangeWeapon()
    {
        //dropZone.cloneNewOnUnsnap = false;
    }
    private void DisableChangeWeapon()
    {
        //dropZone.cloneNewOnUnsnap = true;

    }
}
