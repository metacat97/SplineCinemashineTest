using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text textLabel;
    //[SerializeField] private 
    public DialogueObject textDialogue;

    private ResponseHandler responseHandler;
    private TypeWrite myTextEffect;

    private void Start()
    {
        myTextEffect = GetComponent<TypeWrite>();
        responseHandler = GetComponent<ResponseHandler>();

        CloseDialogueBox();
        //ShowDialogue(textDialogue);
    }

    public void ShowDialogue(DialogueObject dialogueObject)
    {
        dialogueBox.SetActive(true);
        StartCoroutine(StepThroughDialogue(dialogueObject));    
    }

    private IEnumerator StepThroughDialogue(DialogueObject dialogueObject)
    {
        //foreach(string dialogue in dialogueObject.Dialogue)
        //{
        //    yield return myTextEffect.Run(dialogue, textLabel);
        //    yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        //}

        for (int i = 0; i< dialogueObject.Dialogue.Length; i++)
        {
            string dialogue = dialogueObject.Dialogue[i];
            yield return myTextEffect.Run(dialogue, textLabel);

            if (i == dialogueObject.Dialogue.Length - 1 && dialogueObject.HasResponses)//dialogueObject.Responses != null && dialogueObject.Responses.Length > 0)
            {
                break;
            }
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        }

        if (dialogueObject.HasResponses)
        {
            responseHandler.ShowResponses(dialogueObject.Responses);
        }
        else
        {
            CloseDialogueBox();
        }
       // CloseDialogueBox();
    }

    private void CloseDialogueBox()
    {
        dialogueBox.SetActive(false);
        textLabel.text = string.Empty;
    }
}
