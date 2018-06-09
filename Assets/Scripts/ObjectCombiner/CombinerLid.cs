using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinerLid : MonoBehaviour {

    public float timeToMove = 0.5f;

    private Vector3 closedPosition;
    private Vector3 openPosition;

    void Start()
    {
        closedPosition = gameObject.transform.localPosition;
        
//        openPosition = new Vector3(gameObject.transform.localPosition.x - (gameObject.transform.localScale.x- 0.1f), gameObject.transform.localPosition.y, gameObject.transform.localPosition.z);
        openPosition = new Vector3(gameObject.transform.localPosition.x - (1.126f), gameObject.transform.localPosition.y, gameObject.transform.localPosition.z);
        openLid();
    }
    public void openLid()
    {
        StartCoroutine(moveLid(openPosition, timeToMove));
    }
    public void closeLid()
    {
        StartCoroutine(moveLid(closedPosition, timeToMove));
    }

    IEnumerator moveLid(Vector3 newPosition, float time)
    {
        float elapsedTime = 0;
        Vector3 currentPosition = gameObject.transform.localPosition;

        while(elapsedTime < time)
        {
            gameObject.transform.localPosition = Vector3.Lerp(currentPosition, newPosition, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        
    }
}
