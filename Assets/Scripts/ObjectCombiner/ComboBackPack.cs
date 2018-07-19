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

    private BackPackLid bagPackLid;
    private TextMeshPro myText;
    private VRTK_RadialMenu rightHandRadialMenu;
    private VRTK_RadialMenu.RadialMenuButton radialMenuButton;
    private RadialMenuController radialMenuController;
    private bool firstObject = true;
    private bool bagPackFull = false;

    void Start()
    {
        bagPackLid = gameObject.transform.GetComponentInChildren<BackPackLid>();
        myText = gameObject.transform.GetComponentInChildren<TextMeshPro>();
        rightHandRadialMenu = FindObjectOfType<RightHandRadialMenuPanel>().gameObject.GetComponent<VRTK_RadialMenu>();
        radialMenuController = FindObjectOfType<RadialMenuController>();
        radialMenuButton = new VRTK_RadialMenu.RadialMenuButton();
    }

    private void ObjectAddedToBackBag(GameObject objectAdded)
    {
        VRTK_RadialMenu.RadialMenuButton radialMenuButton2;
        radialMenuButton2 = new VRTK_RadialMenu.RadialMenuButton();


        if (rightHandRadialMenu.GetButton(maxButtons - 1) == null)
        {
            if (firstObject)
            {
                rightHandRadialMenu.GetButton(0).ButtonIcon = texture;
                rightHandRadialMenu.GetButton(0).OnClick.AddListener(() => { radialMenuController.SpawnItemToRightHand(objectAdded.tag); });
                firstObject = false;
                objectAdded.transform.position = Vector3.right * 1000;
                StartCoroutine(OpenLid());
                return;
            }

///            rightHandRadialMenu.GetButton(currentButtons).ButtonIcon = texture;
///            rightHandRadialMenu.GetButton(currentButtons).OnClick.AddListener(() => { radialMenuController.SpawnItemToRightHand(objectAdded.tag); });
///            currentButtons++;
            radialMenuButton2.ButtonIcon = texture;
            radialMenuButton2.OnClick.AddListener(() => { radialMenuController.SpawnItemToRightHand(objectAdded.tag); });
            rightHandRadialMenu.AddButton(radialMenuButton2);

            objectAdded.transform.position = Vector3.right * 1000;
            //Destroy(objectAdded);
            if (rightHandRadialMenu.GetButton(maxButtons - 1) != null)
                BackBagFull();
            else
                StartCoroutine(OpenLid());
        }
        else BackBagFull();
    }
    private void BackBagFull()
    {
        bagPackFull = true;
        myText.text = "BackPack Full";
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.tag.StartsWith("Stick"))
        //{
            StartCoroutine(CloseLid(other.gameObject));
        //}
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
