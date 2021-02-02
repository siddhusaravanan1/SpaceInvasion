using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunTurner : MonoBehaviour
{
    void Start()
    {
        
    }
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            transform.localEulerAngles = new Vector3(0, 0, 90);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.localEulerAngles = new Vector3(0, 0, -90);
        }
        if ((Input.GetKeyUp(KeyCode.W))|| (Input.GetKeyUp(KeyCode.S)))
        {
            transform.localEulerAngles = new Vector3(0, 0, 0);
        }
    }
}
