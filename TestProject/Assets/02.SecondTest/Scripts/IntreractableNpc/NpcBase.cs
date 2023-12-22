using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NpcState
{
    Normal,
    Glued,
    ObjectAttached
}
public class NpcBase : MonoBehaviour
{
    
    [SerializeField] protected DialogueUI myDialogue;
    
    protected NpcState npcState;
    protected virtual void Awake()
    {
        myDialogue = GameObject.Find("NpcCanvas").GetComponent<DialogueUI>();
        npcState = NpcState.Normal;
    }

}
