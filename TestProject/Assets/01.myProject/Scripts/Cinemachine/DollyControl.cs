using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollyControl : MonoBehaviour
{
    public CinemachineSmoothPath myDollyTrack;
    public GameObject dollyCamera;
    public CinemachineVirtualCamera myVirtualCam;
    [SerializeField] private CinemachineComposer myComposer;


    // Start is called before the first frame update
    private void Start()
    {
        myComposer =  myVirtualCam.GetCinemachineComponent<CinemachineComposer>(); 
    }
    // Update is called once per frame
    void Update()
    {
        if(dollyCamera.transform.position.x < myDollyTrack.m_Waypoints[0].position.x && 
            dollyCamera.transform.position.x > myDollyTrack.m_Waypoints[6].position.x)
        {
            if (myComposer.m_DeadZoneWidth < 1 || myComposer.m_SoftZoneWidth < 1)
            {
                myComposer.m_DeadZoneWidth +=  Time.deltaTime/2;
                myComposer.m_SoftZoneWidth +=  Time.deltaTime/2;
            }
        }
        else
        {
            if (myComposer.m_DeadZoneWidth > 0 || myComposer.m_SoftZoneWidth > 0)
            {
                myComposer.m_DeadZoneWidth -= Time.deltaTime;
                myComposer.m_SoftZoneWidth -= Time.deltaTime;
            }
            else if(myComposer.m_DeadZoneWidth  < 0 || myComposer.m_SoftZoneWidth < 0)
            {
                myComposer.m_DeadZoneWidth = 0;
                myComposer.m_SoftZoneWidth = 0;
            }

        }

        //Debug.Log(myDollyTrack.m_Waypoints[7].position);
    }
}
