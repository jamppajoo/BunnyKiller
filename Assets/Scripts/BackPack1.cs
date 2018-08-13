using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackPack1 : MonoBehaviour
{

    public GameObject slot1GameObject;
    public GameObject slot2GameObject;
    public GameObject slot3GameObject;
    public GameObject slot4GameObject;

    private HolsterController holsterController;
    private void Start()
    {
        holsterController = FindObjectOfType<HolsterController>();
    }

    public void AddGameObjectToSlot(int slotPosition, GameObject slotObject)
    {
        switch (slotPosition)
        {
            case 1:
                slot1GameObject = slotObject;
                break;
            case 2:
                slot2GameObject = slotObject;
                break;
            case 3:
                slot3GameObject = slotObject;
                break;
            case 4:
                slot4GameObject = slotObject;
                break;
        }
        //holsterController.GetObjectsFromBackPack();
    }
    public void RemoveGameObjectFromSlot(int slotPosition)
    {
        switch (slotPosition)
        {
            case 1:
                slot1GameObject = null;
                break;
            case 2:
                slot2GameObject = null;
                break;
            case 3:
                slot3GameObject = null;
                break;
            case 4:
                slot4GameObject = null;
                break;
        }
    }
}
