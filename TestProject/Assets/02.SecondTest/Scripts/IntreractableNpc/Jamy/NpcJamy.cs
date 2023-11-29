using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcJamy : MonoBehaviour, IInteractableNpc
{
    public string npcName 
    {
        get 
        {
            return transform.name;
        } 
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            InteractButton interactButton = other.gameObject.GetComponent<InteractButton>();
            interactButton.SetText(npcName);
            interactButton.isOnPanel = true;
            interactButton.ControlInteractPanel();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            InteractButton interactButton = other.gameObject.GetComponent<InteractButton>();
            interactButton.ControlInteractPanel();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            InteractButton interactButton = other.gameObject.GetComponent<InteractButton>();
            interactButton.isOnPanel = false;
            interactButton.ControlInteractPanel();
        }
    }

    public void InteractNpc()
    {

    }

    public void ShowInteractButton()
    {
        
    }
}
