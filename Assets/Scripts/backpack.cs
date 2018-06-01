using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backpack : MonoBehaviour {
    public GameObject spawnObject;

	
    private void onTriggerStay(Collider collider)
    {
        VRTK_InteractGrab grabbingObject = (collider.gameobject.GetComponent<VRTK_InteractGrab>() ? collider.gameObject.GetComponent<VRTK_InteractGrab>() : collider.gameObject.GetComponentInParent<VRTK_InteractGrab>());
        if(CanGrab(grabbingObject))
        {
            GameObject spawned = Instatiate(spawnObject);
            grabbingObject.GetComponent<VRTK_InteractGrab>().ForceTouch(spawned);
            grabbingObject.AttemptGrap();
        }
    }
    private bool CanGrab(VRTK_InteractGrab grabbingObject)
    {
        return (grabbingObject && grabbingObject.GetGrabbedObject() == null && grabbingObject.gameobject.GetComponent<VRTK_ControllerEvents>().grabPressed);
    }
}
