using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportArea : MonoBehaviour {

    public BoxCollider garageTeleportArea;

    public void EnableGarageCollider()
    {
        garageTeleportArea.enabled = true;
    }
    public void DisableGarageCollider()
    {
        garageTeleportArea.enabled = false;
    }
}
