using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using VRTK.Examples;

public class HolsterController : MonoBehaviour
{

    private GameObject slot1Weapon;
    private GameObject slot2Weapon;
    private GameObject slot3Weapon;
    private GameObject slot4Weapon;

    private GameObject holster1;
    private GameObject holster2;
    private GameObject holster3;
    private GameObject holster4;

    private VRTK_SnapDropZone slot1DropZone;
    private VRTK_SnapDropZone slot2DropZone;
    private VRTK_SnapDropZone slot3DropZone;
    private VRTK_SnapDropZone slot4DropZone;


    private BackPack1 backPack;

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
        backPack = FindObjectOfType<BackPack1>();

        holster1 = gameObject.transform.Find("Holster1").gameObject;
        holster2 = gameObject.transform.Find("Holster2").gameObject;
        holster3 = gameObject.transform.Find("Holster3").gameObject;
        holster4 = gameObject.transform.Find("Holster4").gameObject;

        slot1DropZone = holster1.GetComponentInChildren<VRTK_SnapDropZone>();
        slot2DropZone = holster2.GetComponentInChildren<VRTK_SnapDropZone>();
        slot3DropZone = holster3.GetComponentInChildren<VRTK_SnapDropZone>();
        slot4DropZone = holster4.GetComponentInChildren<VRTK_SnapDropZone>();

        slot1DropZone.ObjectSnappedToDropZone += new SnapDropZoneEventHandler(ObjectSnappedToDropZone);
        slot2DropZone.ObjectSnappedToDropZone += new SnapDropZoneEventHandler(ObjectSnappedToDropZone);
        slot3DropZone.ObjectSnappedToDropZone += new SnapDropZoneEventHandler(ObjectSnappedToDropZone);
        slot4DropZone.ObjectSnappedToDropZone += new SnapDropZoneEventHandler(ObjectSnappedToDropZone);

        slot1DropZone.ObjectUnsnappedFromDropZone += new SnapDropZoneEventHandler(ObjectUnSnappedFromDropZone);
        slot2DropZone.ObjectUnsnappedFromDropZone += new SnapDropZoneEventHandler(ObjectUnSnappedFromDropZone);
        slot3DropZone.ObjectUnsnappedFromDropZone += new SnapDropZoneEventHandler(ObjectUnSnappedFromDropZone);
        slot4DropZone.ObjectUnsnappedFromDropZone += new SnapDropZoneEventHandler(ObjectUnSnappedFromDropZone);

        EnableChangeWeapon();

    }
    private void ObjectSnappedToDropZone(object sender, SnapDropZoneEventArgs e)
    {
        e.snappedObject.GetComponent<Weapon>().canBeDestroyed = false;
    }
    private void ObjectUnSnappedFromDropZone(object sender, SnapDropZoneEventArgs e)
    {
        e.snappedObject.GetComponent<Weapon>().canBeDestroyed = true;
    }

    private void EnableChangeWeapon()
    {
        slot1DropZone.cloneNewOnUnsnap = false;
        slot2DropZone.cloneNewOnUnsnap = false;
        slot3DropZone.cloneNewOnUnsnap = false;
        slot4DropZone.cloneNewOnUnsnap = false;
    }
    private void DisableChangeWeapon()
    {
        slot1DropZone.cloneNewOnUnsnap = true;
        slot2DropZone.cloneNewOnUnsnap = true;
        slot3DropZone.cloneNewOnUnsnap = true;
        slot4DropZone.cloneNewOnUnsnap = true;

        CheckWeapons();
    }

    private void CheckWeapons()
    {
        slot1Weapon = slot1DropZone.GetCurrentSnappedObject();
        slot2Weapon = slot2DropZone.GetCurrentSnappedObject();
        slot3Weapon = slot3DropZone.GetCurrentSnappedObject();
        slot4Weapon = slot4DropZone.GetCurrentSnappedObject();
    }
    public void GetObjectsFromBackPack()
    {
        slot1Weapon = backPack.slot1GameObject;
        slot2Weapon = backPack.slot2GameObject;
        slot3Weapon = backPack.slot3GameObject;
        slot4Weapon = backPack.slot4GameObject;
        //UpdateHolster();
    }

    private void UpdateHolster()
    {
        slot1DropZone.defaultSnappedObject = slot1Weapon;


        slot2DropZone.defaultSnappedObject = slot2Weapon;
        slot3DropZone.defaultSnappedObject = slot3Weapon;
        slot4DropZone.defaultSnappedObject = slot4Weapon;
    }
}
