namespace VRTK.Examples
{
    using UnityEngine;

    public class SnapDropZoneGroup_Switcher : MonoBehaviour
    {
        public int slotPosition = 0;
        private GameObject baseballBatZone;
        private GameObject lucielleZone;
        private BackPack1 backpack;

        private void Start()
        {
            baseballBatZone = transform.Find("BaseballBat_SnapDropZone").gameObject;
            lucielleZone = transform.Find("Lucielle_SnapDropZone").gameObject;
            backpack = gameObject.transform.parent.GetComponent<BackPack1>();

            baseballBatZone.GetComponent<VRTK_SnapDropZone>().ObjectEnteredSnapDropZone += new SnapDropZoneEventHandler(DoBaseballBatZoneSnapped);
            baseballBatZone.GetComponent<VRTK_SnapDropZone>().ObjectSnappedToDropZone += new SnapDropZoneEventHandler(DoBaseballBatZoneSnapped);
            baseballBatZone.GetComponent<VRTK_SnapDropZone>().ObjectExitedSnapDropZone += new SnapDropZoneEventHandler(DoBaseballBatZoneUnsnapped);
            baseballBatZone.GetComponent<VRTK_SnapDropZone>().ObjectUnsnappedFromDropZone += new SnapDropZoneEventHandler(DoBaseballBatZoneUnsnapped);

            lucielleZone.GetComponent<VRTK_SnapDropZone>().ObjectEnteredSnapDropZone += new SnapDropZoneEventHandler(DoLucielleZoneSnapped);
            lucielleZone.GetComponent<VRTK_SnapDropZone>().ObjectSnappedToDropZone += new SnapDropZoneEventHandler(DoLucielleZoneSnapped);
            lucielleZone.GetComponent<VRTK_SnapDropZone>().ObjectExitedSnapDropZone += new SnapDropZoneEventHandler(DoLucielleZoneUnsnapped);
            lucielleZone.GetComponent<VRTK_SnapDropZone>().ObjectUnsnappedFromDropZone += new SnapDropZoneEventHandler(DoLucielleZoneUnsnapped);
        }

        private void DoBaseballBatZoneSnapped(object sender, SnapDropZoneEventArgs e)
        {
            lucielleZone.SetActive(false);
            GameObject objectToAdd = baseballBatZone.GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject();
            backpack.AddGameObjectToSlot(slotPosition, objectToAdd);
        }

        private void DoBaseballBatZoneUnsnapped(object sender, SnapDropZoneEventArgs e)
        {
            lucielleZone.SetActive(true);
            backpack.RemoveGameObjectFromSlot(slotPosition);
        }

        private void DoLucielleZoneSnapped(object sender, SnapDropZoneEventArgs e)
        {
            baseballBatZone.SetActive(false);
            GameObject objectToAdd = lucielleZone.GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject();
            backpack.AddGameObjectToSlot(slotPosition, objectToAdd);
        }

        private void DoLucielleZoneUnsnapped(object sender, SnapDropZoneEventArgs e)
        {
            baseballBatZone.SetActive(true);
            backpack.RemoveGameObjectFromSlot(slotPosition);
        }
    }
}