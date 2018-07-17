using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class RadialMenuController : MonoBehaviour {

    public List<GameObject> objectsToSpawn = new List<GameObject>();
    public VRTK_ObjectAutoGrab rightHandAutoGrab;
    public VRTK_ObjectAutoGrab leftHandAutoGrab;

    public void SpawnItemToRightHand(string objectToSpawn)
    {
        foreach(GameObject item in objectsToSpawn)
        {
            if(item.tag == objectToSpawn)
            {
                rightHandAutoGrab.ClearPreviousClone();
                rightHandAutoGrab.objectToGrab = item.GetComponent<VRTK_InteractableObject>();
                rightHandAutoGrab.SpawnObject();
            }
        }

    }
    public void SpawnItemToLefttHand(string objectToSpawn)
    {
        foreach (GameObject item in objectsToSpawn)
        {
            if (item.tag == objectToSpawn)
            {
                leftHandAutoGrab.ClearPreviousClone();
                leftHandAutoGrab.objectToGrab = item.GetComponent<VRTK_InteractableObject>();
                leftHandAutoGrab.SpawnObject();
            }
        }
    }
}
