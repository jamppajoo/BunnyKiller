using UnityEngine;
using VRTK;

public class WeaponCombine : MonoBehaviour {



    private VRTK_SnapDropZone dropZone;
    private GameObject attachedObject;
    private VRTK_PolicyList policyList;

    void Start () {

        dropZone = GetComponent<VRTK_SnapDropZone>();
        policyList = GetComponent<VRTK_PolicyList>();

        dropZone.ObjectSnappedToDropZone += new SnapDropZoneEventHandler(ObjectAttached);
		
	}

    private void ObjectAttached(object sender, SnapDropZoneEventArgs e)
    {
        attachedObject = e.snappedObject;
        DisableChildCollider();
        DisableSnapDropZone();
    }
    private void DisableChildCollider()
    {
        attachedObject.gameObject.GetComponent<Collider>().enabled = false;
    }
    private void DisableSnapDropZone()
    {
        policyList.identifiers.Clear();
    }
}
