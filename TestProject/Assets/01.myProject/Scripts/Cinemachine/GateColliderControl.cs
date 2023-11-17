using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class GateColliderControl : MonoBehaviour
{
    public CinemachineVirtualCamera myCamera;
    public CinemachineVirtualCamera downCamera;
    public CinemachineVirtualCamera downCamera2;



    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("이게 트리거 온");
        if (other.tag  == "Player")
        {
            myCamera.Priority = 11;
            downCamera.Priority = 10;
            downCamera2.Priority = 10;
        }
    }
}
