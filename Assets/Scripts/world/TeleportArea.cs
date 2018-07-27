using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportArea : MonoBehaviour {

    public BoxCollider garageTeleportArea;

    private void OnEnable()
    {
        EventManager.WaveStarted += DisableGarageCollider;
        EventManager.WaveEnded += EnableGarageCollider;
    }
    private void OnDisable()
    {
        EventManager.WaveStarted -= DisableGarageCollider;
        EventManager.WaveEnded -= EnableGarageCollider;
    }

    private void EnableGarageCollider()
    {
        garageTeleportArea.enabled = true;
    }
    private void DisableGarageCollider()
    {
        garageTeleportArea.enabled = false;
    }
}
