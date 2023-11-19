using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class FollowSpline : MonoBehaviour
{
    public static bool isStop = default;
    public SplineContainer mySpline;
    [SerializeField] private float objSpeed = 1f;
    float distancePercentage = 0f;
    float splineLength;

    public Vector3 stopStationPos = Vector3.zero;

    public TestSpline testSplineScript = default;
    void Start()
    {
        splineLength = mySpline.CalculateLength();
        isStop = true;
    }
   
    void Update()
    {
        if (!isStop)
        {
            //distancePercentage += objSpeed * Time.deltaTime / splineLength;

            //Vector3 currentPosition = mySpline.EvaluatePosition(distancePercentage);
            //Vector3 currentForward = mySpline.EvaluateTangent(distancePercentage);
            //transform.position = currentPosition;

            //if (distancePercentage > 1f)
            //{
            //    distancePercentage = 0f;
            //}

            //Vector3 nextPosition = mySpline.EvaluatePosition(distancePercentage + 0.05f);
            //Vector3 direction = nextPosition - currentPosition;
            //transform.right = currentForward;
            FollowSplinePath();
        }
       

        //transform.rotation = Quaternion.LookRotation(direction, transform.up);
        //transform.rotation = Quaternion.LookRotation(direction, transform.up);

    }
    public void FollowSplinePath()
    {
        distancePercentage += objSpeed * Time.deltaTime / splineLength;
        Vector3 currentPosition = mySpline.EvaluatePosition(distancePercentage);
        transform.position = currentPosition;

        if (distancePercentage > 1f)
        {
            distancePercentage = 0f;
        }

        Vector3 nextPosition = mySpline.EvaluatePosition(distancePercentage + 0.05f);
        Vector3 direction = nextPosition - currentPosition;
        transform.rotation = Quaternion.LookRotation(direction, transform.up);
    }

    public void StopBus()
    {
        isStop = true;
    }

    public void GoBus()
    {
        isStop = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.LogFormat("이게 트리거고 포지션 값{0}",other.transform.position);
        if (other.tag == "BusStop")
        {
            CheckStopPoint(stopStationPos, other.transform.position);
        }
    }

    public void CheckStopPoint(Vector3 goalPos, Vector3 checkPos)
    {
        if(goalPos == checkPos)
        {
            StopBus();
        }
        else
        {
            GoBus();
        }
    }
    public void GoFirstStation()
    {
        Debug.Log("1번 누름");
        stopStationPos = testSplineScript.savePositionList[0];
    }
    public void GoSecondStation() 
    {
        Debug.Log("2번 누름");
        stopStationPos = testSplineScript.savePositionList[1];
    }
    public void GoThirdStation()
    {
        Debug.Log("3번 누름");
        stopStationPos = testSplineScript.savePositionList[2];
    }
    public void GoFourthStation() 
    {
        Debug.Log("4번 누름");
        stopStationPos = testSplineScript.savePositionList[3];
    }
    public void GoFifthStation() 
    {
        Debug.Log("5번 누름");
        stopStationPos = testSplineScript.savePositionList[4];
    }
}
