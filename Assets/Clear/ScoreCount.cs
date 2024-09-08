using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCount : MonoBehaviour
{
    string a;
    [SerializeField] TextMeshProUGUI m_TextMeshPro;
    // Start is called before the first frame update
    void Start()
    {
        int test = ScoreManager.totalScore;
        a = test.ToString();
        m_TextMeshPro.text = a;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
