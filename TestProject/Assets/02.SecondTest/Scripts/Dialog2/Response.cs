using UnityEngine;

[System.Serializable]
public class Response 
{
    //응답 상자 UI 내부에 표시할 텍스트와
    //대화 상자 개체에 대한 포인터 참조 포함
    [SerializeField] private string responseText;
    [SerializeField] private DialogueObject dialogueObject;

    public string ResponseText => responseText;
    public DialogueObject DialogueObject => dialogueObject;

}
