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
        startGame();
    }

    public void startGame()
    {
        health = 10;
        for(int i=0;i<10;i++)
        {
            for(int j=0; j<10;j++)
            {
                //smaller yard
                //GameObject carrot = Instantiate(carrotObject, new Vector3(-6.81f+(i*0.7f), 0.04f, -3.45f+(j*0.7f)), Quaternion.identity);
                
                GameObject carrot = Instantiate(carrotObject, new Vector3(-16.1f + (i * 1.6f), 0.04f, -7.45f + (j * 1.6f)), Quaternion.identity);
                carrot.isStatic = true;
                carrot.GetComponent<CarrotHealth>().health = health;
                carrot.transform.parent = carrotParent.transform;
            }
        }
        
    }
}

