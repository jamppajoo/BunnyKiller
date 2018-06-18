using UnityEngine;
using System.Collections;
using TMPro; // Add the TextMesh Pro namespace to access the various functions.


public class ScoreText : MonoBehaviour
{

    public TextMeshPro TmpPrefab;

    private TextMeshPro m_TMP_Score;
    private TextMeshPro m_TMP_Health;

    void Awake()
    {
        m_TMP_Score = Instantiate(TmpPrefab);
        m_TMP_Score.text = "The score.";
        // Add logic to position and do other stuff with the object.

        m_TMP_Health = Instantiate(TmpPrefab);
        m_TMP_Health.text = "100";
        // Add logic to position and do other stuff with the object.
    }
}