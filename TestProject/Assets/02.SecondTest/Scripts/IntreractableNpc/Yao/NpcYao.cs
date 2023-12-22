using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class NpcYao : NpcBase, IInteractableNpc
{
    public string npcName
    {
        get
        {
            return transform.name;
        }
    }

    private bool isCurrentObject = false;

    protected override void Awake()
    {
        base.Awake();
        
    }
    

    void Update()
    {
        Debug.Log(npcState);
        if (isCurrentObject)
        {
            ChangeNpcState(NpcState.ObjectAttached);
        }
        else
        {
            return;
        }
    }

    public void InteractNpc()
    {
       
    }

    public void ChangeNpcState(NpcState _change)
    {
        npcState = _change;
    }
}
