using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickManager : MonoBehaviour
{
    [SerializeField] GameObject[] gimmickObjects;

    GameObject putObject;


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

            mousePosition.x = Mathf.Clamp(mousePosition.x, -5.0f + scale, 5.0f - scale);
            mousePosition.y = Mathf.Clamp(mousePosition.y, -5.0f + scale, 12.0f - scale);

            putObject.transform.position = mousePosition;
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(gimmickObjects[1], mousePosition, Quaternion.identity);
                SoundManager.PlaySE(SoundManager.SE.SET_X);
            }
        }
        if (Input.GetMouseButtonDown(1) && putObject == null)
        {
            putObject = Instantiate(gimmickObjects[1], GetMousePosition(), Quaternion.identity);
            for (int i = 0; i < putObject.transform.childCount; i++)
            {
                putObject.transform.GetChild(i).GetComponent<BoxCollider>().isTrigger = true;
                putObject.transform.GetChild(i).GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1, 0.5f);
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
    }
}
