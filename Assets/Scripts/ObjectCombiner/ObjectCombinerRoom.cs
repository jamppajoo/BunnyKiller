using System.Collections;
using UnityEngine;

public class ObjectCombinerRoom : MonoBehaviour {
    public float timeToMoveDoors = 1f;
    public GameObject leftDoor, rightDoor;
    private Vector3 leftDoorOpenPosition, rightDoorOpenPosition;
    private Vector3 leftDoorClosedPosition, rightDoorClosedPosition;
    private WaveController waveController;

    private bool playerIsInRoom = false;

    private void Start()
    {
        waveController = GameObject.FindObjectOfType<WaveController>();

        leftDoorOpenPosition = leftDoor.transform.position;
        rightDoorOpenPosition = rightDoor.transform.position;

        leftDoorClosedPosition = new Vector3(leftDoorOpenPosition.x, leftDoorOpenPosition.y, leftDoorOpenPosition.z +2);
        rightDoorClosedPosition = new Vector3(rightDoorOpenPosition.x, rightDoorOpenPosition.y, rightDoorOpenPosition.z -2);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            OpenDoors();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            CloseDoors();
        }
    }

    public void OpenDoors()
    {
        print("OPEN DOOR");
        StartCoroutine(MoveDoor(leftDoor, leftDoorOpenPosition, timeToMoveDoors));
        StartCoroutine(MoveDoor(rightDoor, rightDoorOpenPosition, timeToMoveDoors));
    }

    public void CloseDoors()
    {
        StartCoroutine(MoveDoor(leftDoor, leftDoorClosedPosition, timeToMoveDoors));
        StartCoroutine(MoveDoor(rightDoor, rightDoorClosedPosition, timeToMoveDoors));
    }
    IEnumerator MoveDoor(GameObject door, Vector3 toPosition, float time)
    {
        float elapsedTime = 0;
        Vector3 currentPosition = door.transform.position;

        while(elapsedTime < time)
        {
            door.transform.position = Vector3.Lerp(currentPosition, toPosition, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Player")
        {
            playerIsInRoom = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            print("Player has left the building");
            playerIsInRoom = false;
            CloseDoors();
            waveController.StartWave();
        }
    }


}


public class LevelExitCollider : MonoBehaviour
{

    public bool playerHasEntered = false;
//    private LevelExitTime levelExitTime;
    private GameObject killedBunniesObj;

//    private GameObject deathButtonObj;
//    private GameObject deadliestTrapObj;
//    private GameObject deadliestTrapText;
    private AnalyticsClass analyticsValues;
//    public List<Sprite> spriteList;
//    [SerializeField]
//    private List<string> trapNameList;
//    private LevelManager levelManager;

    void Start()
    {
        //        levelExitTime = FindObjectOfType<LevelExitTime>();
        killedBunniesObj = GameObject.Find("killedBunnies");

        ///analyticsValues = AnalyticsClass.analyticsResults;

        /*        deathButtonObj = GameObject.Find("deathValue");
                deadliestTrapObj = GameObject.Find("deadliestTrap");
                deadliestTrapText = GameObject.Find("deadliestTrapText");

                trapNameList = new List<string>();
                trapNameList.Add("  BLENDER");
                trapNameList.Add("  LASER");
                trapNameList.Add("  TURRET");
                trapNameList.Add("  LASERBLENDER");
                levelManager = FindObjectOfType<LevelManager>();
        */
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerCollider" && !playerHasEntered)
        {
            playerHasEntered = true;
            //            levelExitTime.TimerStop();
///            killedBunniesObj.GetComponent<Text>().text = analyticsValues.rotationCount.ToString();
//            deathButtonObj.GetComponent<Text>().text = analyticsValues.deathCount.ToString();
//            deadliestTrapObj.GetComponent<Image>().sprite = spriteList[analyticsValues.getDeadliestTrap()];
//            deadliestTrapText.GetComponent<Text>().text = trapNameList[analyticsValues.getDeadliestTrap()];
//            levelManager.EndLevel();
        }
    }
}
