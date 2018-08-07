using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class SpawnerIgnoreCollisionWithBody : MonoBehaviour {

    private VRTK_SnapDropZone dropZone;
    private VRTK_BodyPhysics bodyPhysics;

    private void Awake()
    {
        dropZone = GetComponent<VRTK_SnapDropZone>();
        bodyPhysics = FindObjectOfType<VRTK_BodyPhysics>();
        dropZone.ObjectUnsnappedFromDropZone += new SnapDropZoneEventHandler(ObjectUnSnappedFromDropZone);
    }
    private void ObjectUnSnappedFromDropZone(object sender, SnapDropZoneEventArgs e)
    {
    }
}
