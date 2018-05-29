using System.Collections.Generic;
using UnityEngine;

public class ObjectCombiner : MonoBehaviour {

    [System.Serializable]
    public class MyClass
    {
        public string AnTag1;
        public string AnTag2;
        public GameObject AnOutput;
    }

    public List<MyClass> MyList = new List<MyClass>(1);
    
    private List<GameObject> objectsInCombiner = new List<GameObject>();
    
	void Start () {
		
	}
	
	void Update () {

	}

    public void AddNew()
    {
        MyList.Add(new MyClass());
    }

    public void Remove(int index)
    {
        MyList.RemoveAt(index);
    }


    private void SpawnObject(GameObject object1, GameObject object2 ,GameObject output)
    {
        objectsInCombiner.Clear();
        Destroy(object1);
        Destroy(object2);

        Instantiate(output);
    }

    private void OnTriggerEnter(Collider other)
    {
        objectsInCombiner.Add(other.gameObject);
    }
    private void OnTriggerExit(Collider other)
    {
        objectsInCombiner.Remove(other.gameObject);
    }


}
