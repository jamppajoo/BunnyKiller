using System.Collections.Generic;
using UnityEngine;

public class BloodSpatter : MonoBehaviour {

    public List<GameObject> bloodSpatters = new List<GameObject>();

    private int bloodSpatterType ;
    private void Start()
    {
       
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.B))
        {
            KillBunny();
        }
    }
    public void KillBunny()
    {
        bloodSpatterType = Random.Range(0, bloodSpatters.Count);
        Instantiate(bloodSpatters[bloodSpatterType]);
    }
	
}
