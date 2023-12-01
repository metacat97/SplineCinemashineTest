using UnityEngine;

[System.Serializable]
public class Response 
{
    //���� ���� UI ���ο� ǥ���� �ؽ�Ʈ��
    //��ȭ ���� ��ü�� ���� ������ ���� ����
    [SerializeField] private string responseText;
    [SerializeField] private DialogueObject dialogueObject;

    public string ResponseText => responseText;
    public DialogueObject DialogueObject => dialogueObject;

}
