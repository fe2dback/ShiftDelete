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
        if (targetPos.y > 79f && targetPos.x > 18)
        {
            transform.position = new Vector3(36, 88, -1);
        }
        else if (targetPos.y > 58f && targetPos.x > 18)
        {
            transform.position = new Vector3(36, 68, -1);
        }
        else if (targetPos.y > 38f && targetPos.x > 18)
        {
            transform.position = new Vector3(36, 48, -1);
        }
        else if (targetPos.y > 38f)
        {
            transform.position = new Vector3(0, 48, -1);
        }
        else if(targetPos.y > 28f)
        {
            transform.position = new Vector3(0, 38, -1);
        }

        else if (targetPos.y > 10f)
        {
            transform.position = new Vector3(0, 18, -1);
        }
        else
        {
            transform.position = new Vector3(0, 0, -1);
        }
    }


   

}
