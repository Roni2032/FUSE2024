using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] Button btn;
    [SerializeField] GameObject generateObj;
    private ScoreManager scoreManager;
    private int score;
    private float cost;

    public float GetCost()//�R�X�g��n��
    {
        return cost;
    }

    // Start is called before the first frame update
    void Start()
    {
        cost = generateObj.GetComponent<Gimmick>().GetRate();//�R�X�g���擾
        GameObject obj = GameObject.Find("ScoreManager");//�X�R�A�}�l�[�W���[���擾
        scoreManager = obj.GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
        score = scoreManager.GetScore();
        btn.interactable = (score >= cost);//�X�R�A���R�X�g��荂����΃I���ɂȂ�

    }
}
