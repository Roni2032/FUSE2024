using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreImageManager : MonoBehaviour
{
    public NumberImage[] m_NumberImage;
    public int m_score = 0;

    // Start is called before the first frame update
    void Start()
    {
        //”Žš‚Ìƒ[ƒ‚É–ß‚é
        //strScore[0] - '0'
        
    }

    // Update is called once per frame
    void Update()
    {
        if (m_score > 99999)
        {
            m_score = 99999;
        }
        //•¶Žš—ñ‚É•ÏŠ·
        string strScore = m_score.ToString("00000");

        for (int i = 0; i < m_NumberImage.Length; i++)
        {
            m_NumberImage[i].DisplayNum(strScore[i] - '0');
        }


    }
}
