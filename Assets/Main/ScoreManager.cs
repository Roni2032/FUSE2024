using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//スコア（お金の管理です）
public class ScoreManager : MonoBehaviour
{
    public static int totalScore;//現在の合計スコア

    public void AddScore(int score)//スコアがプラスする
    {
        totalScore += score;
        Debug.Log("SCORE : " + totalScore);
    }
    public void SubtractScore(int score)//スコアがマイナスする
    {
        totalScore -= score;
        Debug.Log("SCORE :" + totalScore);
    }

    public int GetScore()//スコアのゲッター
    {
        return totalScore;
    }


    // Start is called before the first frame update
    void Start()
    {
        SoundManager.PlayBGM();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
