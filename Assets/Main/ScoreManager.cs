using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//�X�R�A�i�����̊Ǘ��ł��j
public class ScoreManager : MonoBehaviour
{
    public static int totalScore;//���݂̍��v�X�R�A

    public void AddScore(int score)//�X�R�A���v���X����
    {
        totalScore += score;
        Debug.Log("SCORE : " + totalScore);
    }
    public void SubtractScore(int score)//�X�R�A���}�C�i�X����
    {
        totalScore -= score;
        Debug.Log("SCORE :" + totalScore);
    }

    public int GetScore()//�X�R�A�̃Q�b�^�[
    {
        return totalScore;
    }



    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);//�V�[���ڍs���Ă��������g���������Ȃ�
    }

    // Update is called once per frame
    void Update()
    {

    }
}
