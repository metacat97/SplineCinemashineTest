using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CallBus : MonoBehaviour
{
    public Button hochulBtn;
    public Button closeBtn;
    public GameObject dochackjiPanel;

    TestSpline test = new TestSpline();

    public void Start()
    {
        dochackjiPanel.SetActive(false);
        closeBtn.gameObject.SetActive(false);
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
        if(dochackjiPanel.activeSelf == true)
        {
            ClickCloseBtn();
        }
    }

    public void ClickBtn()
    {
        hochulBtn.gameObject.SetActive(false);
        dochackjiPanel.SetActive(true);
        closeBtn.gameObject.SetActive(true);
    }

    public void ClickCloseBtn()
    {
        closeBtn.gameObject.SetActive(false);
        dochackjiPanel.SetActive(false);
        hochulBtn.gameObject.SetActive(true);
    }

}
