using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCount : MonoBehaviour
{
    string a;
    // Start is called before the first frame update
    void Start()
    {
        int test = ScoreManager.totalScore;
        a = test.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TextMeshPro>().text = a;
    }
}
