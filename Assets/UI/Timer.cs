using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] string m_sceneName;
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
        if (Time.timeScale == 0)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 1;
                SceneManager.LoadScene(m_sceneName);
            }
            return;
        }
        m_currentTime -= Time.deltaTime;

        m_timer.fillAmount = m_currentTime / m_time;
        Debug.Log(m_currentTime);

        if(m_currentTime < 0)
        {
            m_currentTime = 0;
            Time.timeScale = 0;
            SoundManager.PlaySE(SoundManager.SE.TIMEUP);
            SoundManager.StopBGM();
        }
    }


}
