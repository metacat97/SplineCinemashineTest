using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcAmy : NpcBase , IInteractableNpc
{
    public string npcName
    {
        get
        {
            return transform.name;
        }
    }

    public DialogueObject amyDialogue;

    private bool isCurrentObject = false;
   
    protected override void Awake()
    {
        base.Awake();
        amyDialogue = myDialogue.textDialogue;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (CompareTag("Bus"))
        {
            isCurrentObject = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (CompareTag("Bus"))
        {
            isCurrentObject = false;
        }
    }

    void Update()
    {
        Debug.Log(npcState);
        if(isCurrentObject)
        {
            //previousAmyState = npcState; 
            ChangeNpcState(NpcState.ObjectAttached);
        }
        else  
        {
            return;
            //if (npcState == NpcState.Glued)
            //{
            //    npcState = NpcState.Glued;
            //    return;
            //}


            //if (npcState != NpcState.Glued) 
            //{
            //    Debug.Log("º»µå ¹¯ÇôÁø »óÅÂ°¡ ¾Æ´Ò¶§ µé¾î¿È")
            //    ChangeNpcState(NpcState.Normal);
            //}
        }
    }

    public void InteractNpc()
    {
        myDialogue.ShowDialogue(amyDialogue);
    }

    public void ChangeNpcState(NpcState _change)
    {
        npcState = _change;
    }
}
