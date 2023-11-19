using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Splines;


public class TestSpline : MonoBehaviour
{
    public int choiceNum = 0;
    public SplineContainer mySpline;
    
    Vector3 savePosition = default;
    public GameObject subwayPointPrefab;
    //public List <Vector3> savePositionList = new List<Vector3> ();
    public List<Vector3> savePositionList { get; private set; } = new List<Vector3>();
    private void Awake()
    {
        TestSplinePath();
    }

    public void TestSplinePath()
    {
        for (int i = 0; i < mySpline.Splines[0].ToArray().Length; i++)
        {
            savePosition = mySpline.Splines[0].Knots.ToArray()[i].Position;
            savePosition += mySpline.transform.position;
            savePositionList.Add(savePosition);
            Instantiate(subwayPointPrefab, new Vector3(savePosition.x, savePosition.y, savePosition.z), Quaternion.identity);
        }

        foreach (var dot in savePositionList)
        {
            Debug.Log(dot);
            //savePosition = knot.Position;
            //if (savePosition == goalPosition.)
        }
    }
    #region ÁÖ¼®
    //public bool Evaluate<T>(T spline, float t, out float3 position, out  float3 tangent, out float3 upVector) where T: ISpline
    //{
    //    if (spline == null)
    //    {
    //        position = float3.zero;
    //        tangent = new float3(0f, 0f, 1f);
    //        upVector = new float3(0f, 1f, 0f);
    //        return false;
    //    }

    //    if (IsScaled)
    //    {
    //        using var nativeSpline = new NativeSpline(spline, transform.localToWorldMatrix);
    //        return SplineUtility.Evaluate(nativeSpline, t , out position, out tangent, out upVector);
    //    }
    //    var evaluationStatus = SplineUtility.Evaluate(spline, t , out position, out tangent, out upVector);
    //    if(evaluationStatus)
    //    {
    //        position = transform.TransformPoint(position);
    //        tangent = transform.TransformVector(tangent);
    //        upVector = transform.TransformDirection(upVector);
    //    }
    //    return evaluationStatus;
    //}
    #endregion
}
