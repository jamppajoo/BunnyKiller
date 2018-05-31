using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCombiner : MonoBehaviour
{
    public float timeToCheckCombination = 2f;
    [System.Serializable]
    public class MyClass
    {
        public string AnTag1;
        public string AnTag2;
        public GameObject AnOutput;
    }

    [HideInInspector]
    public List<MyClass> MyList = new List<MyClass>(1);

    private List<GameObject> objectsInCombiner = new List<GameObject>();
    private CombinerLid combinerLid;

    private int objectsInCombinerAmount = 0;

    private float timer = 0;

    private bool foundOne = false;

    private void Start()
    {
        combinerLid = gameObject.transform.GetComponentInChildren<CombinerLid>();
    }
    private void CheckCombination()
    {

        List<string> objectsInCombinerTags = new List<string>();
        for (int i = 0; i < objectsInCombiner.Count; i++)
        {
            objectsInCombinerTags.Add(objectsInCombiner[i].gameObject.tag);
        }
        foreach (MyClass item in MyList)
        {
            if (objectsInCombinerTags.Contains(item.AnTag1) && objectsInCombinerTags.Contains(item.AnTag2))
            {
                StartCoroutine(WaitCombination(objectsInCombiner, item.AnOutput, true));
                //SpawnObject(objectsInCombiner, item.AnOutput);
            }
            else
                StartCoroutine(WaitCombination(null, null, false));
        }
    }

    public void AddNew()
    {
        MyList.Add(new MyClass());
    }

    public void Remove(int index)
    {
        MyList.RemoveAt(index);
    }

    private void SpitOutObjects(List<GameObject> objects)
    {
        foreach (GameObject item in objects)
        {
            if (item.GetComponent<Rigidbody>())
            {
                item.GetComponent<Rigidbody>().AddForce(new Vector3(0, 3, -.5f), ForceMode.Impulse);
                //item.GetComponent<Rigidbody>().isKinematic = true;x   

            }
        }
    }

    private void SpawnObject(List<GameObject> objects, GameObject output)
    {
        for (int i = 0; i < objects.Count; i++)
        {
            Destroy(objects[i]);
        }
        objectsInCombiner.Clear();
        objectsInCombinerAmount = 0;
        GameObject outputResult = Instantiate(output, gameObject.transform.position, Quaternion.identity);
        objectsInCombiner.Add(outputResult);
    }

    IEnumerator WaitCombination(List<GameObject> objects, GameObject output, bool isValid)
    {
        combinerLid.closeLid();
        yield return new WaitForSeconds(combinerLid.timeToMove);
        if (isValid)
            SpawnObject(objects, output);
        yield return new WaitForSeconds(2);
        combinerLid.openLid();
        yield return new WaitForSeconds(combinerLid.timeToMove);
        SpitOutObjects(objectsInCombiner);


    }
    private void OnTriggerEnter(Collider other)
    {
        if (!objectsInCombiner.Contains(other.gameObject))
            objectsInCombiner.Add(other.gameObject);
        objectsInCombinerAmount++;
        if (objectsInCombinerAmount == 2)
            CheckCombination();
    }
    private void OnTriggerExit(Collider other)
    {
        objectsInCombiner.Remove(other.gameObject);
        objectsInCombinerAmount--;
    }



}
