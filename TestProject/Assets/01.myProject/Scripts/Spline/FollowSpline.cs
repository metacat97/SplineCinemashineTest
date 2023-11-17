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
    void Start()
    {
        splineLength = mySpline.CalculateLength();
        isStop = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T)) 
        {
            isStop = true;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            isStop = false;
        }

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
}
