namespace VRTK.Examples
{
    using UnityEngine;

    public class SnapDropZoneGroup_Switcher : MonoBehaviour
    {
        public int slotPosition = 0;
        private GameObject baseballBatZone;
        private GameObject lucielleZone;
        private BackPack1 backpack;

        private VRTK_SnapDropZone baseballBatDropZone;

        private VRTK_SnapDropZone lucielleDropZone;

        private GameObject baseBallbat;
        private GameObject lucielle;


        private void Start()
        {
            backpack = gameObject.transform.parent.GetComponent<BackPack1>();

            baseballBatZone = transform.Find("BaseballBat_SnapDropZone").gameObject;
            lucielleZone = transform.Find("Lucielle_SnapDropZone").gameObject;

            baseballBatDropZone = baseballBatZone.GetComponent<VRTK_SnapDropZone>();
            lucielleDropZone = lucielleZone.GetComponent<VRTK_SnapDropZone>();

            //baseballBatDropZone.ObjectEnteredSnapDropZone += new SnapDropZoneEventHandler(DoBaseballBatZoneSnapped);
            baseballBatDropZone.ObjectSnappedToDropZone += new SnapDropZoneEventHandler(DoBaseballBatZoneSnapped);
            baseballBatDropZone.ObjectExitedSnapDropZone += new SnapDropZoneEventHandler(DoBaseballBatZoneUnsnapped);
            baseballBatDropZone.ObjectUnsnappedFromDropZone += new SnapDropZoneEventHandler(DoBaseballBatZoneUnsnapped);

            //lucielleDropZone.ObjectEnteredSnapDropZone += new SnapDropZoneEventHandler(DoLucielleZoneSnapped);
            lucielleDropZone.ObjectSnappedToDropZone += new SnapDropZoneEventHandler(DoLucielleZoneSnapped);
            lucielleDropZone.ObjectExitedSnapDropZone += new SnapDropZoneEventHandler(DoLucielleZoneUnsnapped);
            lucielleDropZone.ObjectUnsnappedFromDropZone += new SnapDropZoneEventHandler(DoLucielleZoneUnsnapped);
        }

        private void DoBaseballBatZoneSnapped(object sender, SnapDropZoneEventArgs e)
        {

            baseBallbat = baseballBatDropZone.GetCurrentSnappedObject();
            baseBallbat.GetComponent<Weapon>().canBeDestroyed = false;

            lucielleZone.SetActive(false);
            backpack.AddGameObjectToSlot(slotPosition, baseBallbat);
        }

        private void DoBaseballBatZoneUnsnapped(object sender, SnapDropZoneEventArgs e)
        {
            if (baseBallbat != null)
            {
                baseBallbat.GetComponent<Weapon>().canBeDestroyed = true;
                baseBallbat = null;
            }
            lucielleZone.SetActive(true);
            backpack.RemoveGameObjectFromSlot(slotPosition);
        }

        private void DoLucielleZoneSnapped(object sender, SnapDropZoneEventArgs e)
        {

            lucielle = lucielleDropZone.GetCurrentSnappedObject();
            lucielle.GetComponent<Weapon>().canBeDestroyed = false;


            baseballBatZone.SetActive(false);
            backpack.AddGameObjectToSlot(slotPosition, lucielle);

        }

        private void DoLucielleZoneUnsnapped(object sender, SnapDropZoneEventArgs e)
        {
            if (lucielle != null)
            {
                lucielle.GetComponent<Weapon>().canBeDestroyed = true;
                lucielle = null;
            }
            baseballBatZone.SetActive(true);
            backpack.RemoveGameObjectFromSlot(slotPosition);
            
        }
        
    }
}