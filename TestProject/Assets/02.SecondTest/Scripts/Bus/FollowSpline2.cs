using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class FollowSpline2 : MonoBehaviour
{
    //�̵��ϰԵ� ���ö��� �����̳�
    public SplineContainer mySpline;

    //������Ʈ�� �̵��ӵ�
    [SerializeField] private float objSpeed = 1f;
    //�̵� �Ÿ�
    float distancePercentage = 0f;
    float splineLength;

    //������Ʈ ������ ����
    public bool isStop = default;
    public bool isOneToZero = false;
    int currentPosIdx = 0;
    public bool isArrived = false;
    //����� �ϴ� ������ ������
    public Vector3 stopStationPos = Vector3.zero;

    //������ ������ �������� ���� ��ũ��Ʈ
    public StationManager stationInfo = default;


    void Start()
    {
        AddOnButtonEvent();
        splineLength = mySpline.CalculateLength();
        isOneToZero = false;
        isStop = true;
        //currentPosIdx = stationInfo.stationBtns.Count;
    }
    
    void Update()
    {
        if (!isStop)
        {
            //FollowZeroToOne();

            if (!isOneToZero)
            {
                FollowZeroToOne();
            }
            else
            {
                FollowOneToZero();
            }
        }
    }
    //{������ ������ bool�� �� ����
    public void FollowZeroToOne()
    {
        distancePercentage += objSpeed * Time.deltaTime / splineLength;
        Vector3 currentPosition = mySpline.EvaluatePosition(distancePercentage);
        transform.position = currentPosition;

        if (distancePercentage > 1f)
        {
            distancePercentage = 0f;

            //return;
        }
        
        Vector3 nextPosition = mySpline.EvaluatePosition(distancePercentage + 0.00001f);
        Vector3 direction = nextPosition - currentPosition;
        Vector3 perpendicularVector = Vector3.Cross(direction, transform.up);
        transform.rotation = Quaternion.LookRotation(new Vector3(direction.x, perpendicularVector.y, direction.z), transform.up);
    }
    public void FollowOneToZero()
    {
        distancePercentage -= objSpeed * Time.deltaTime / splineLength;
        Vector3 currentPosition = mySpline.EvaluatePosition(distancePercentage);
        transform.position = currentPosition;

        if (distancePercentage < 0f)
        {
            distancePercentage = 1f;
            //return;
        }

        Vector3 nextPosition = mySpline.EvaluatePosition(distancePercentage - 0.00001f);
        Vector3 direction = nextPosition - currentPosition;
        Vector3 perpendicularVector = Vector3.Cross(direction, transform.up);
        transform.rotation = Quaternion.LookRotation(new Vector3(direction.x, perpendicularVector.y, direction.z), transform.up);
    }
    public void StopBus()
    {
        isStop = true;
    }
    public void GoBus()
    {
        isStop = false;
    }
    //}������ ������ bool�� �� ����

    //{��ư�� �̺�Ʈ �߰�
    private void AddOnButtonEvent()
    {
        for (int i = 0; i < stationInfo.stationBtns.Count; i++)
        {
            int currentIndex = i;
            stationInfo.stationBtns[i].onClick.AddListener(() => GoBus());
           
            stationInfo.stationBtns[i].onClick.AddListener(() => GoStation(currentIndex));
        
        }
    }
    //}��ư�� �̺�Ʈ �߰�

    //{��Ʈ���� �̺�Ʈ
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BusStop")
        {
            CheckStopPoint(stopStationPos, other.transform.position);
        }
        if (other.tag == "LoadableItem")
        {
            AddLoadableItem();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "BusStop")
        {
            isArrived = false;
            stationInfo.CloseBusCanvas();
        }
    }
    //}��Ʈ���� �̺�Ʈ

    //{���ߴ� ���� Ȯ��
    private void CheckStopPoint(Vector3 goalPos, Vector3 checkPos)
    {
        if (goalPos == checkPos)
        {
            StopBus();
            stationInfo.OpenBusCanvas();
            isArrived = true;
        }
        else
        {
            isArrived = false;
            stationInfo.CloseBusCanvas();
            GoBus();
        }
    }
    //}���ߴ� ���� Ȯ��

    //{�÷��̾� ���� ���
    public void GoStation(int goalPositionIdx)
    {
        isArrived = false;

        stopStationPos = stationInfo.savePositionList[goalPositionIdx];

        if (currentPosIdx > goalPositionIdx)
        {
            isOneToZero = true;
        }
        else if (currentPosIdx == goalPositionIdx)
        {
            //�̰Ŷ����� �������̴� �ſ���.ó����
            isStop = true;
            return;
        }
        else
        {
            stationInfo.CloseBusCanvas();
            isOneToZero = false;
        }
        CheckDirection(currentPosIdx, goalPositionIdx);
        currentPosIdx = goalPositionIdx;
    }
    //} �÷��̾� ���� ���

    private void CheckDirection(int nowIdx, int destinationIdx)
    {
        //CheckDirection(currentPosIdx, goalPositionIdx); ��뿹
        
        int forwardD;
        int reverseD;
        Debug.LogFormat("����{0}",nowIdx);
        Debug.LogFormat("������{0}",destinationIdx);
        if (nowIdx > destinationIdx)
        {
            forwardD = nowIdx - destinationIdx; //6
            reverseD = (stationInfo.stationBtns.Count - nowIdx) +  destinationIdx; //2
                Debug.Log("���� ����?");
            if (forwardD > reverseD)
            {

                isOneToZero = false;
            }
            else
            {
                isOneToZero = true;
            }
        }
        else
        {
            forwardD = destinationIdx - nowIdx; //6
            reverseD = (stationInfo.stationBtns.Count - destinationIdx) + nowIdx;
            if (forwardD > reverseD)
            {
                Debug.Log("���� ����?");
                isOneToZero = true;
            }
            else
            {
                isOneToZero = false;
            }
        }
        

    }

    //���߿� ������ �߰�
    public virtual void AddLoadableItem()
    {
        //���⿡ �߰�?
    }

}
