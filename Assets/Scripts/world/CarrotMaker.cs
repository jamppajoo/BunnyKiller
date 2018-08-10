using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotMaker : MonoBehaviour {

    public GameObject carrotObject;
    public int amount;
    public int health = 10;
    public int maded = 0;
    private GameObject carrotParent;
    
    void Start()
    {
        carrotParent = GameObject.Find("carrotsParent");
        startGame2();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void startGame()
    {
        /*
        GameObject carrot = Instantiate(carrotObject, new Vector3(-7.440001f, 0.04f, -3.67f), Quaternion.identity);
        carrot.GetComponent<CarrotHealth>().health = health;
        carrot.transform.parent = carrotParent.transform;

        GameObject carrot2 = Instantiate(carrotObject, new Vector3(-7.31f, 0.04f, 3.45f), Quaternion.identity);
        carrot.GetComponent<CarrotHealth>().health = health;
        carrot2.transform.parent = carrotParent.transform;

        GameObject carrot3 = Instantiate(carrotObject, new Vector3(-1.78f, 0.04f, 3.53f), Quaternion.identity);
        carrot.GetComponent<CarrotHealth>().health = health;
        carrot3.transform.parent = carrotParent.transform;

        GameObject carrot4 = Instantiate(carrotObject, new Vector3(-1.75f, 0.04f, -3.58f), Quaternion.identity);
        carrot.GetComponent<CarrotHealth>().health = health;
        carrot4.transform.parent = carrotParent.transform;

        GameObject carrot5 = Instantiate(carrotObject, new Vector3(-4.66f, 0.04f, -0.32f), Quaternion.identity);
        carrot.GetComponent<CarrotHealth>().health = health;
        carrot5.transform.parent = carrotParent.transform;
        */
        
        /*
        GameObject carrot = Instantiate(carrotObject, new Vector3(-6.81f, 0.04f, -3.45f), Quaternion.identity);
        carrot.GetComponent<CarrotHealth>().health = health;
        carrot.transform.parent = carrotParent.transform;

        GameObject carrot2 = Instantiate(carrotObject, new Vector3(-6.81f, 0.04f, 3.45f), Quaternion.identity);
        carrot2.GetComponent<CarrotHealth>().health = health;
        carrot2.transform.parent = carrotParent.transform;

        GameObject carrot3 = Instantiate(carrotObject, new Vector3(-0.83f, 0.04f, 3.45f), Quaternion.identity);
        carrot3.GetComponent<CarrotHealth>().health = health;
        carrot3.transform.parent = carrotParent.transform;

        GameObject carrot4 = Instantiate(carrotObject, new Vector3(-0.83f, 0.04f, -3.45f), Quaternion.identity);
        carrot4.GetComponent<CarrotHealth>().health = health;
        carrot4.transform.parent = carrotParent.transform;

        GameObject carrot5 = Instantiate(carrotObject, new Vector3(-3.82f, 0.04f, -0.32f), Quaternion.identity);
        carrot5.GetComponent<CarrotHealth>().health = health;
        carrot5.transform.parent = carrotParent.transform;
        */
    }

    public void startGame2()
    {
        health = 10;
        for(int i=0;i<10;i++)
        {
            for(int j=0; j<10;j++)
            {
                //                GameObject carrot = Instantiate(carrotObject, new Vector3(-6.81f+(i*0.7f), 0.04f, -3.45f+(j*0.7f)), Quaternion.identity);
                //GameObject carrot = Instantiate(carrotObject, new Vector3(-8.5f + (i * 1.6f), 0.04f, -5.45f + (j * 1.6f)), Quaternion.identity);
                GameObject carrot = Instantiate(carrotObject, new Vector3(-16.1f + (i * 1.6f), 0.04f, -7.45f + (j * 1.6f)), Quaternion.identity);
                carrot.isStatic = true;
                carrot.GetComponent<CarrotHealth>().health = health;
                carrot.transform.parent = carrotParent.transform;
            }
        }
        
    }
}

