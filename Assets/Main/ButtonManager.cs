using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] int cost;
    [SerializeField] Button btn;
    private ScoreManager scoreManager;
    private int score;

    public int GetCost()//コストを渡す
    {
        return cost;
    }

    // Start is called before the first frame update
    void Start()
    {
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
