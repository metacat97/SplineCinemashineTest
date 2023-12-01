using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcJamy : MonoBehaviour, IInteractableNpc
{
    public GameObject dialog1;
    public GameObject dialog2;

    public DialogueUI myDialogue;
    public DialogueObject textDialogue;
    public string npcName 
    {
        get 
        {
            return transform.name;
        } 
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        InteractButton interactButton = other.gameObject.GetComponent<InteractButton>();
    //        interactButton.SetText(npcName);
    //        interactButton.isOnPanel = true;
    //        interactButton.ControlInteractPanel();
    //    }
    //}
    //private void OnTriggerStay(Collider other)
    //{
    //    if(other.tag == "Player")
    //    {
    //        InteractButton interactButton = other.gameObject.GetComponent<InteractButton>();
    //        interactButton.ControlInteractPanel();
    //    }
    //}
    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        InteractButton interactButton = other.gameObject.GetComponent<InteractButton>();
    //        interactButton.isOnPanel = false;
    //        interactButton.ControlInteractPanel();
    //    }
    //}

    private void Awake()
    {
        myDialogue = GetComponent<DialogueUI>();
    }
    public void Start()
    {
        dialog1.gameObject.SetActive(false);
        dialog2.gameObject.SetActive(false);

    }
    public void InteractNpc()
    {
        Debug.Log("npcJamy Interact 실행");
    }

    public void PushButton()
    {
        Debug.Log("npcJamy PushButton 실행");
        //dialog1.gameObject.SetActive(true);
        //dialog2.gameObject.SetActive(true);
        //StartCoroutine(DialogueManager.instance.StartDialoge());
        myDialogue.ShowDialogue(textDialogue);

    }
    
}
