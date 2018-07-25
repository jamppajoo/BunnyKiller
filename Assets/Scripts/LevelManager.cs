using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    // make a tag list what weapons might go to backbag
    [HideInInspector]
    public List<string> rightHandObjectTags = new List<string>();
    [HideInInspector]
    public List<string> leftHandObjectTags = new List<string>();


    public bool IsRightHandObjectTag(string tag)
    {
        foreach (string item in rightHandObjectTags)
        {
            if (item == tag)
                return true;
        }
        return false;
    }

}
