using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickManager : MonoBehaviour
{
    [SerializeField] GameObject[] gimmickObjects;
    [SerializeField] ScoreManager scoreManager;

    GameObject putObject;
    int putIndex = 2;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (putObject != null)
        {
            bool isCanPut = true;
            Vector3 mousePosition = GetMousePosition();
            float scale = putObject.GetComponent<Gimmick>().GetPutScale();

            if(mousePosition.x > 9.5f - scale || mousePosition.x < -9.5f + scale || mousePosition.y > 19.0f - scale || mousePosition.y < 1.0f + scale)
            {
                isCanPut = false;
                putObject.GetComponentInChildren<MeshRenderer>().material.color = new Color(1, 0, 0, 0.5f);
                
            }
            else
            {
                putObject.GetComponentInChildren<MeshRenderer>().material.color = new Color(1, 1, 1, 0.5f);
            }
            putObject.transform.position = mousePosition;
            if (Input.GetMouseButtonDown(0) && isCanPut)
            {
                Gimmick gimmick = Instantiate(gimmickObjects[putIndex], mousePosition, Quaternion.identity).GetComponent<Gimmick>();
                SoundManager.PlaySE(SoundManager.SE.SET_X);
                gimmick.SetSpin(putObject.GetComponent<Gimmick>().GetSpin());
                scoreManager.SubtractScore(gimmick.GetRate());
                Destroy(putObject);
                putObject = null;
            }
            if (Input.GetMouseButtonDown(1))
            {
                putObject.GetComponent<Gimmick>().ChangeSpin();
                SoundManager.PlaySE(SoundManager.SE.GET_MONEY);
            }
        }
        
    }
    
    Vector3 GetMousePosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 23.0f;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        worldPosition.z = 0.0f;
        return worldPosition;
    }

    public void PushPreviewGimmickButton(int num)
    {
        if(num >= gimmickObjects.Length)
        {
            num = gimmickObjects.Length - 1;
        }

        putObject = Instantiate(gimmickObjects[num], GetMousePosition(), Quaternion.identity);
        putObject.GetComponentInChildren<MeshRenderer>().material.color = new Color(1, 1, 1, 0.5f);
        for (int i = 0; i < putObject.transform.childCount - 1; i++)
        {
            putObject.transform.GetChild(i).GetComponent<BoxCollider>().isTrigger = true;
            
        }
        putIndex = num;
    }
}
