using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickManager : MonoBehaviour
{
    [SerializeField] GameObject[] gimmickObjects;

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
            Vector3 mousePosition = GetMousePosition();
            float scale = putObject.GetComponent<Gimmick>().GetPutScale();

            mousePosition.x = Mathf.Clamp(mousePosition.x, -9.5f + scale, 9.5f - scale);
            mousePosition.y = Mathf.Clamp(mousePosition.y, 1.0f + scale, 19.0f - scale);

            putObject.transform.position = mousePosition;
            if (Input.GetMouseButtonDown(0))
            {
                Gimmick gimmick = Instantiate(gimmickObjects[putIndex], mousePosition, Quaternion.identity).GetComponent<Gimmick>();
                SoundManager.PlaySE(SoundManager.SE.SET_X);
                gimmick.SetSpin(putObject.GetComponent<Gimmick>().GetSpin());
                Destroy(putObject);
                putObject = null;
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            if (putObject == null)
            {
                putObject = Instantiate(gimmickObjects[putIndex], GetMousePosition(), Quaternion.identity);
                for (int i = 0; i < putObject.transform.childCount; i++)
                {
                    putObject.transform.GetChild(i).GetComponent<BoxCollider>().isTrigger = true;
                    putObject.transform.GetChild(i).GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1, 0.5f);
                }
            }
            else
            {
                putObject.GetComponent<Gimmick>().ChangeSpin();
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
        for (int i = 0; i < putObject.transform.childCount; i++)
        {
            putObject.transform.GetChild(i).GetComponent<BoxCollider>().isTrigger = true;
            putObject.transform.GetChild(i).GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1, 0.5f);
        }
        putIndex = num;
    }
}
