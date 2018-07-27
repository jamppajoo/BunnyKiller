﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using VRTK;

public class ComboBackPack : MonoBehaviour
{

    public int maxButtons = 4;
    private int currentButtons = 1;
    public Sprite texture;
    public int slotNumber;

    private BackPackLid bagPackLid;
    private TextMeshPro myText;
    private VRTK_RadialMenu rightHandRadialMenu;
    //    private VRTK_RadialMenu.RadialMenuButton radialMenuButton;
    private RadialMenuController radialMenuController;
    private bool firstObject = true;
    private bool bagPackFull = false;
    private LevelManager levelManager;
    private GameObject slotImage;

    private void OnEnable()
    {
        EventManager.WaveEnded += EmptyBackBag;
    }

    private void OnDisable()
    {
        EventManager.WaveEnded -= EmptyBackBag;
    }
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        bagPackLid = gameObject.transform.GetComponentInChildren<BackPackLid>();
        myText = gameObject.transform.GetComponentInChildren<TextMeshPro>();
        rightHandRadialMenu = FindObjectOfType<RightHandRadialMenuPanel>().gameObject.GetComponent<VRTK_RadialMenu>();
        radialMenuController = FindObjectOfType<RadialMenuController>();
        //        radialMenuButton = new VRTK_RadialMenu.RadialMenuButton();
    }

    private void ObjectAddedToBackBag(GameObject objectAdded)
    {
        VRTK_RadialMenu.RadialMenuButton radialMenuButton;
        radialMenuButton = new VRTK_RadialMenu.RadialMenuButton();

        if (rightHandRadialMenu.GetButton(maxButtons - 1) == null)
        {
            if (firstObject)
            {
                rightHandRadialMenu.GetButton(0).ButtonIcon = texture;
                rightHandRadialMenu.GetButton(0).OnClick.AddListener(() => { radialMenuController.SpawnItemToRightHand(objectAdded.tag); });
                firstObject = false;
                objectAdded.transform.position = Vector3.right * 1000;
                StartCoroutine(OpenLid());
                addImagetoSlot(rightHandRadialMenu.buttons.Count, objectAdded);
                return;
            }

            radialMenuButton.ButtonIcon = texture;
            radialMenuButton.OnClick.AddListener(() => { radialMenuController.SpawnItemToRightHand(objectAdded.tag); });
            rightHandRadialMenu.AddButton(radialMenuButton);

            objectAdded.transform.position = Vector3.right * 1000;
            //if (rightHandRadialMenu.GetButton(maxButtons - 1) != null)
            //    BackBagFull();
            //else 
            StartCoroutine(OpenLid());
            addImagetoSlot(rightHandRadialMenu.buttons.Count, objectAdded);
        }
        else
        {
            rightHandRadialMenu.GetButton(slotNumber).ButtonIcon = texture;
            rightHandRadialMenu.GetButton(slotNumber).OnClick.AddListener(() => { radialMenuController.SpawnItemToRightHand(objectAdded.tag); });
            addImagetoSlot(slotNumber, objectAdded);
        }
        
        //            BackBagFull();
    }
    private void addImagetoSlot(int slot, GameObject objectAdded)
    {
        //Load image
        
    }
    private void BackBagFull()
    {
        bagPackFull = true;
        myText.text = "BackPack Full";
        firstObject = true;
    }

    private void EmptyBackBag()
    {
        VRTK_RadialMenu.RadialMenuButton radialMenuButton;
        radialMenuButton = new VRTK_RadialMenu.RadialMenuButton();
        radialMenuButton.ButtonIcon = texture;

        rightHandRadialMenu.buttons.Clear();
        rightHandRadialMenu.AddButton(radialMenuButton);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (levelManager.IsRightHandObjectTag(other.gameObject.tag))
        {
            StartCoroutine(CloseLid(other.gameObject));
        }
    }
    IEnumerator CloseLid(GameObject other)
    {
        bagPackLid.closeLid();
        yield return new WaitForSeconds(bagPackLid.timeToMove + 1);
        ObjectAddedToBackBag(other);
    }

    IEnumerator OpenLid()
    {
        bagPackLid.openLid();
        yield return new WaitForSeconds(bagPackLid.timeToMove);
    }
}
