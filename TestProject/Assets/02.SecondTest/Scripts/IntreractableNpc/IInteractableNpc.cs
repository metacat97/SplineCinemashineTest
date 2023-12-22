using UnityEngine;

public interface IInteractableNpc
{
    public string npcName {  get; }
    public void InteractNpc();
    public void PushButton()
    {

    }
    public void ChangeNpcState(NpcState _change)
    {

    }
    
}
