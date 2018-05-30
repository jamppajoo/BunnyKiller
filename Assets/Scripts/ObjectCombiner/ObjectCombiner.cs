using System.Collections.Generic;
using UnityEngine;

public class ObjectCombiner : MonoBehaviour
{

    [System.Serializable]
    public class MyClass
    {
        public string AnTag1;
        public string AnTag2;
        public GameObject AnOutput;
    }

    public List<MyClass> MyList = new List<MyClass>(1);

    private List<GameObject> objectsInCombiner = new List<GameObject>();

    private int objectsInCombinerAmount = 0;

    private bool foundOne = false;

    void Start()
    {

    }

    void Update()
    {


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
            if(objectsInCombinerTags.Contains(item.AnTag1) && objectsInCombinerTags.Contains(item.AnTag2))
            {
                SpawnObject(objectsInCombiner, item.AnOutput);
            }
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


    private void SpawnObject(List<GameObject> objects, GameObject output)
    {
        for (int i = 0; i < objects.Count; i++)
        {
            Destroy(objects[i]);
        }
        objectsInCombiner.Clear();
        objectsInCombinerAmount = 0;
        Instantiate(output);
    }

    private void OnTriggerEnter(Collider other)
    {
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
