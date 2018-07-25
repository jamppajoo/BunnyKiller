using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class RadialMenuController : MonoBehaviour {

    public List<GameObject> objectsToSpawnRightHand = new List<GameObject>();
    public List<GameObject> objectsToSpawnLeftHand = new List<GameObject>();
    public VRTK_ObjectAutoGrab rightHandAutoGrab;
    public VRTK_ObjectAutoGrab leftHandAutoGrab;


    private LevelManager levelManager;
    private void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        foreach (GameObject item in objectsToSpawnRightHand)
        {
            levelManager.rightHandObjectTags.Add(item.gameObject.tag);
        }
        foreach (GameObject item in objectsToSpawnLeftHand)
        {
            levelManager.leftHandObjectTags.Add(item.gameObject.tag);
        }

    }
    public void SpawnItemToRightHand(string objectToSpawn)
    {
        foreach(GameObject item in objectsToSpawnRightHand)
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
        foreach (GameObject item in objectsToSpawnLeftHand)
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
