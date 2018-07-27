using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granade : MonoBehaviour
{

    public float timeToExplode = 5;
    public float blastRadius = 5;
    public float blastForce = 1;
    public List<GameObject> fragments = new List<GameObject>();
    List<GameObject> createdFragments = new List<GameObject>();
    GameObject fragmentHolder;

    private void Start()
    {
        StartCoroutine(StartExplosion());
    }

    public void ExplodeGranade()
    {
        fragmentHolder = new GameObject("FragmentHolder");
        fragmentHolder.transform.position = gameObject.transform.position;
        fragmentHolder.transform.localScale = gameObject.transform.localScale;
        fragmentHolder.transform.rotation = gameObject.transform.rotation;

        foreach (GameObject item in fragments)
        {
            createdFragments.Add(Instantiate(item, fragmentHolder.transform));
        }

        ThrowFragments();
    }

    private void ThrowFragments()
    {

        foreach (GameObject item in createdFragments)
        {

            Rigidbody fragmentRB = item.GetComponent<Rigidbody>();
            fragmentRB.AddExplosionForce(blastForce, fragmentHolder.transform.position, blastRadius);
        }
        Destroy(gameObject);
    }

    private IEnumerator StartExplosion()
    {
        yield return new WaitForSeconds(timeToExplode);
        ExplodeGranade();
    }
    
    
}
