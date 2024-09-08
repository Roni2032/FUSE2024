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

    public float GetCost()//コストを渡す
    {
        return cost;
    }

    // Start is called before the first frame update
    void Start()
    {
        cost = generateObj.GetComponent<Gimmick>().GetRate();//コストを取得
        GameObject obj = GameObject.Find("ScoreManager");//スコアマネージャーを取得
        scoreManager = obj.GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
        score = scoreManager.GetScore();
        btn.interactable = (score >= cost);//スコアがコストより高ければオンになる

    }
}
