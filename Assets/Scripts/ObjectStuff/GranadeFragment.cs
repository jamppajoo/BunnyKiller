using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GranadeFragment : MonoBehaviour {

    public float fragmentDestroyTime = 3;

	void Start () {
        StartCoroutine(DestroyFragment());
	}
	
	IEnumerator DestroyFragment()
    {
        yield return new WaitForSeconds(fragmentDestroyTime);
        if (GameObject.Find("FragmentHolder"))
            Destroy(GameObject.Find("FragmentHolder"));
        Destroy(gameObject);
    }
}
