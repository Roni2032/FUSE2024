using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberImage : MonoBehaviour
{
    public Sprite[] m_sprite = new Sprite[10];
    public Image m_image;

    // Start is called before the first frame update
    void Start()
    {
        DisplayNum(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void DisplayNum(int num)
    {
        m_image.sprite = m_sprite[num];
    }
}
