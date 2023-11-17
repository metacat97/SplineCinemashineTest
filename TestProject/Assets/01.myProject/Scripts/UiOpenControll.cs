using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiOpenControll : MonoBehaviour
{
    public GameObject friendScreen;
    public GameObject partyScreen;

    public void OpenOrCloseScreen(GameObject screenObj)
    {
        if(screenObj.activeSelf == false)
        {
            screenObj.SetActive(true);
        }
        else if (screenObj.activeSelf == true) 
        {
            screenObj.SetActive(false);
        }
    }
    
}
