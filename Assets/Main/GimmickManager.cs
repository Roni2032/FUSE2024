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
            putObject.transform.position = GetMousePosition();
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(gimmickObjects[0], GetMousePosition(), Quaternion.identity);
            }
        }
        if (Input.GetMouseButtonDown(1) && putObject == null)
        {
            putObject = Instantiate(gimmickObjects[0], GetMousePosition(), Quaternion.identity);
            for (int i = 0; i < putObject.transform.childCount; i++)
            {
                putObject.transform.GetChild(i).GetComponent<BoxCollider>().isTrigger = true;
        }
        }
    }

    Vector3 GetMousePosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 10.0f;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        worldPosition.z = 0.0f;
        return worldPosition;
    }

    void PushPreviewGimmickButton(int num)
    {
        if(num >= gimmickObjects.Length)
        {
            num = gimmickObjects.Length - 1;
        }
    }
}
