using UnityEngine;
using VRTK;

public class WeaponCombine : MonoBehaviour {

    private GameObject parentObject;

    private VRTK_SnapDropZone dropZone;
    private GameObject attachedObject;
    private VRTK_PolicyList policyList;

    private LayerMask weaponLayerMask;



    void Start () {


        weaponLayerMask = LayerMask.NameToLayer("Weapon");

        parentObject = gameObject.transform.parent.gameObject;

        dropZone = GetComponent<VRTK_SnapDropZone>();
        policyList = GetComponent<VRTK_PolicyList>();

        dropZone.ObjectSnappedToDropZone += new SnapDropZoneEventHandler(ObjectAttached);
		
	}

    private void ObjectAttached(object sender, SnapDropZoneEventArgs e)
    {
        attachedObject = e.snappedObject;

        // Disable is grabbable so child object cannot be seperated
        attachedObject.GetComponent<VRTK_InteractableObject>().isGrabbable = false; 
        // Disable can be destroyed so objects does'nt disappear after wave
        attachedObject.GetComponent<Weapon>().canBeDestroyed = false;
        //Changes layers so objects does'nt collide with eachother and start messing around
        DisableChildCollision();
        //Disable drop zone to ignore doulbe dropzone tries on one slot
        DisableSnapDropZone();
    }
    private void DisableChildCollision()
    {
        attachedObject.layer = weaponLayerMask;
        parentObject.layer = weaponLayerMask;
    }
    private void DisableSnapDropZone()
    {
        gameObject.GetComponent<Collider>().enabled = false;
    }
}
