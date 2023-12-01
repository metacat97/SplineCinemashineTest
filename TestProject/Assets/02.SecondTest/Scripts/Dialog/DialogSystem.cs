using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class DialogSystem : MonoBehaviour
{
    [SerializeField] private Speaker[]      speakers;   // ��ȭ�� �����ϴ� ĳ���͵��� UI�迭
    [SerializeField] private DialogData[]   dialogs;    // ���� �б��� ��� ��� �迭

    [SerializeField] 
    private bool    isAutoStart         = true;         // �ڵ� ���� ����
    private bool    isFirst             = true;         // ���� 1ȸ�� ȣ���ϱ����� ����
    private int     currentDialogIndex  = -1;           // ���� ��� ����
    private int     currentSpeakerIndex = 0;            // ���� ���� �ϴ� ȭ���� �迭 ����


    private void Awake()
    {
        Setup();
    }

    private void Setup()
    {
        // ��� ��ȭ ���� ���� ������Ʈ ��Ȱ��ȭ
        for (int i = 0; i < speakers.Length; ++i)
        {
            SetActiveObjects(speakers[i], false);
            // ĳ���� �̹����� ���̵��� ����
            speakers[i].spriteRenderer.gameObject.SetActive(true);
        }
    }

    public bool UpdateDialog()
    {
        // ��� �бⰡ ���۵� �� 1ȸ�� ȣ��
        if (isFirst == true)
        {
            //�ʱ�ȭ. ĳ���� �̹����� Ȱ��ȭ�ϰ�, ��� ���� UI�� ��� ��Ȱ��ȭ
            Setup();

            // �ڵ� ���(isAutoStart = true) ���� �����Ǿ� ������ ù ��° ��� ���
            if ( isAutoStart )
            {
                SetNextDialog();
                isFirst = false;
            }
        }

        if ( Input.GetMouseButtonDown(0))
        {
            // ��簡 �������� ��� ���� ��� ����
            if (dialogs.Length > currentDialogIndex +1)
            {
                SetNextDialog();
            }
            // ��簡 �� �̻� ���� ��� ��� ������Ʈ�� ��Ȱ��ȭ�ϰ�  true ��ȯ
            else
            {
                for( int i = 0; i < speakers.Length; ++i)
                {
                    SetActiveObjects(speakers[i], false);
                    //SetActiveObjects() �� ĳ���� �̹����� ������ �ʰ� �ϴ� �κ��� ���⿡ ���� ȣ��
                    speakers[i].spriteRenderer.gameObject.SetActive(false);
                }
                return true; 
            }
        }
        return false;
    }

    private void SetNextDialog()
    {
        //���� ȭ���� ��ȭ ���� ������Ʈ ��Ȱ��ȭ
        SetActiveObjects(speakers[currentSpeakerIndex], false);

        //���� ��縦 �����ϵ���
        currentDialogIndex++;

        //���� ȭ�� ���� ����
        currentSpeakerIndex = dialogs[currentDialogIndex].speakerIndex;

        //���� ȭ���� ��ȭ ���� ������Ʈ Ȱ��ȭ
        SetActiveObjects(speakers[currentSpeakerIndex], true);

        //���� ȭ�� �̸� �ؽ�Ʈ ����
        speakers[currentSpeakerIndex].textName.text = dialogs[currentDialogIndex].name;

        //���� ȭ���� ��� �ؽ�Ʈ ����
        speakers[currentSpeakerIndex].textDialogue.text = dialogs[currentSpeakerIndex].dialogue;
    }

    private void SetActiveObjects(Speaker speaker, bool visible)
    {
        speaker.imageDialog.gameObject.SetActive(visible);
        speaker.textName.gameObject.SetActive(visible);
        speaker.textDialogue.gameObject.SetActive(visible);

        //ȭ��ǥ�� ��簡 ����Ǿ��� ���� Ȱ��ȭ�ϱ� ������ �׻� false
        speaker.ojjectArrow.SetActive(false);

        //ĳ���� ���� �� ����
        Color color = speaker.spriteRenderer.color;
        color.a = visible == true ? 1 : 0.2f;
        speaker.spriteRenderer.color = color;
    }
}


[System.Serializable]
public struct Speaker
{
    public SpriteRenderer spriteRenderer;     // ĳ���� �̹���(û��/ȭ�� ���İ� ����)
    public Image          imageDialog;        // ��ȭâ Image UiI
    public TextMeshProUGUI textName;            // ���� ������� ĳ���� �̸�
    public TextMeshProUGUI textDialogue;        // ���� ��� ��� TextUI
    public GameObject ojjectArrow;              // ��簡 �Ϸ�Ǿ��� �� ��µǴ� Ŀ��
}


[System.Serializable]
public struct DialogData
{
    public int      speakerIndex;    // �̸��� ��縦 ����� ���� speaekr �� �迭 ����
    public string   name;            // ĳ���� �̸�
    [TextArea(3, 5)]
    public string dialogue;          // ���
}
