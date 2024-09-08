using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Image m_timer;
    public float m_time;
    float m_currentTime;
    // Start is called before the first frame update
    void Start()
    {
        m_currentTime = m_time;
    }

    // Update is called once per frame
    void Update()
    {
        m_currentTime -= Time.deltaTime;

        m_timer.fillAmount = m_currentTime / m_time;
        Debug.Log(m_currentTime);
    }


}
