using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreArea : MonoBehaviour
{
    [SerializeField] int score;
    [SerializeField]ScoreManager scoreManager;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "ball")
        {
            scoreManager.AddScore(score);
            Destroy(other.gameObject);
            SoundManager.PlaySE(SoundManager.SE.GET_MONEY);
        }
    }
}
