using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam : MonoBehaviour
{
    private Transform camt;
    public Transform target;
    private Vector3 targetPos;


    // Start is called before the first frame update
    void Start()
    {
        
        
        
    }


    void Update()
    {
        
        targetPos =  target.position;
        if(targetPos.y > 10f)
        {
            transform.position = new Vector3(0, 18, -1);
        }
        else
        {
            transform.position = new Vector3(0, 0, -1);
        }
    }


   

}
