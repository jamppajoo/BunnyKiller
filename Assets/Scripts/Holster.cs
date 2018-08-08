using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Holster : MonoBehaviour {


    private GameObject weapon;

    private VRTK_SnapDropZone dropZone;
    private MeshRenderer meshRenderer;

    private void OnEnable()
    {
        EventManager.WaveStarted += DisableChangeWeapon;
        EventManager.WaveOnHold += EnableChangeWeapon;
    }
    private void OnDisable()
    {
        EventManager.WaveStarted -= DisableChangeWeapon;
        EventManager.WaveOnHold -= EnableChangeWeapon;
        dropZone.ObjectSnappedToDropZone -= new SnapDropZoneEventHandler(ObjectSnappedToDropZone);
        dropZone.ObjectUnsnappedFromDropZone -= new SnapDropZoneEventHandler(ObjectUnSnappedFromDropZone);

    }

    private void Start()
    {
        dropZone = GetComponent<VRTK_SnapDropZone>();
        meshRenderer = GetComponent<MeshRenderer>();

        dropZone.ObjectSnappedToDropZone += new SnapDropZoneEventHandler(ObjectSnappedToDropZone);
        dropZone.ObjectUnsnappedFromDropZone += new SnapDropZoneEventHandler(ObjectUnSnappedFromDropZone);
        EnableChangeWeapon();
    }


    private void ObjectSnappedToDropZone(object sender, SnapDropZoneEventArgs e)
    {
        weapon = e.snappedObject;
        meshRenderer.enabled = false;
    }
    private void ObjectUnSnappedFromDropZone(object sender, SnapDropZoneEventArgs e)
    {
        weapon = null;
        meshRenderer.enabled = true;
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
