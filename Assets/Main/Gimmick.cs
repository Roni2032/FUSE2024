using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gimmick : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] int putRate;
    [SerializeField] float putScale;
    // Start is called before the first frame update
    public float GetPutScale()
    {
        return putScale;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0,0,speed) * Time.deltaTime);
    }
}
