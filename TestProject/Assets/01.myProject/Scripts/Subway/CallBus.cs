using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CallBus : MonoBehaviour
{
    public Button hochulBtn;
    public GameObject dochackjiPanel;

    TestSpline test = new TestSpline();

    public void Start()
    {
        dochackjiPanel.SetActive(false);
        hochulBtn.interactable = false;
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            hochulBtn.interactable = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            hochulBtn.interactable = false;
        }
    }

    public void ClickBtn()
    {
        hochulBtn.gameObject.SetActive(false);
        dochackjiPanel.SetActive(true);
    }

    public Vector3 GoFirstPlace(Vector3 arrivePlace)
    {
        return arrivePlace;
    }


    

}
