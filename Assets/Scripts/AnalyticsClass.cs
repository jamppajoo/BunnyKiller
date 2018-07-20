using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using Valve.VR.InteractionSystem;

public class AnalyticsClass : MonoBehaviour
{
	//public static AnalyticsClass analyticsResults;

	public int killedBunniesCount;
    public List<KilledByListObject> killedByList = new List<KilledByListObject>();

    private void Start()
    {
        killedBunniesCount = 0;
        killedByList.Add(new KilledByListObject(""));
    }

	public void addKilledBunny()
	{
		killedBunniesCount = killedBunniesCount + 1;
	}

    public void deathListCounter(string weaponThatKilled)
    {
        bool added = false;
        foreach (KilledByListObject killedObject in killedByList)
        {
            if (killedObject.weaponName.Equals(weaponThatKilled))
            { 
                killedObject.killedAmount++;
                added = true;
                break;
            }
        }
        if(!added)killedByList.Add(new KilledByListObject(weaponThatKilled));
    }

    public void printList()
    {
        killedByList.ToString();
        foreach (KilledByListObject killedObject in killedByList)
        {
            print(killedObject.weaponName + " " + killedObject.killedAmount);
        }
        if (killedByList == null) print("Empty list");
    }

    public void resetEvents()
	{
        killedBunniesCount = 0;
	}

	public void onDestroy()
	{
        killedBunniesCount = 0;
    }

    public void levelRestart()
    {
        killedBunniesCount = 0;
    }

    void OnApplicationQuit()
	{
		if(!Application.isEditor)
		Analytics.CustomEvent("Total playtime", new Dictionary<string, object>
		{
			{"Time", Time.realtimeSinceStartup }
		});
	}
}

public class KilledByListObject
{
    public string weaponName;
    public int killedAmount;

    public KilledByListObject(string WeaponName)
    {
        weaponName = WeaponName;
        killedAmount = 1;
    }
}

/*
 * How to use
 * This add different strings to deathlistcounter. That list keeps tracking amount of every string. When used just add names of the weapons to keep track how many times every weapon has killed bunny
  
        public static AnalyticsClass analyticsResults = new AnalyticsClass();
      
        objectCombinerRoom = FindObjectOfType<ObjectCombinerRoom>();
        analyticsResults.deathListCounter("bb");
        analyticsResults.deathListCounter("cc");
        analyticsResults.deathListCounter("bb");
        analyticsResults.deathListCounter("bb");
        analyticsResults.deathListCounter("cc");
        analyticsResults.deathListCounter("aa");
        analyticsResults.printList();

*/
