using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class PriorityControl : MonoBehaviour
{
    public CinemachineVirtualCamera myVCam1;
    public CinemachineVirtualCamera myVCam2;

   

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.D))
        {
            myVCam2.Priority = 11;
        }
        else if(Input.GetKeyDown(KeyCode.A))
        {
            myVCam2.Priority = 9;
        }
    }
}
