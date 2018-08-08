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

    private void Start()
    {
        holster1 = gameObject.transform.Find("Holster1").gameObject;
        holster2 = gameObject.transform.Find("Holster2").gameObject;
        holster3 = gameObject.transform.Find("Holster3").gameObject;
        holster4 = gameObject.transform.Find("Holster4").gameObject;

        slot1DropZone = holster1.GetComponent<VRTK_SnapDropZone>();
        slot2DropZone = holster2.GetComponent<VRTK_SnapDropZone>();
        slot3DropZone = holster3.GetComponent<VRTK_SnapDropZone>();
        slot4DropZone = holster4.GetComponent<VRTK_SnapDropZone>();
    }

    public VRTK_SnapDropZone GetEmptyDropZone()
    {
        if (slot1Weapon == null)
            return slot1DropZone;
        if (slot2Weapon == null)
            return slot2DropZone;
        if (slot3Weapon == null)
            return slot3DropZone;
        if (slot4Weapon == null)
            return slot4DropZone;
        else return null;
    }

    private void CheckWeapons()
    {
        slot1Weapon = slot1DropZone.GetCurrentSnappedObject();
        slot2Weapon = slot2DropZone.GetCurrentSnappedObject();
        slot3Weapon = slot3DropZone.GetCurrentSnappedObject();
        slot4Weapon = slot4DropZone.GetCurrentSnappedObject();
    }
    
}
