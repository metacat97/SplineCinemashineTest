using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class DialogSystem : MonoBehaviour
{
    [SerializeField] private Speaker[]      speakers;   // 대화에 참여하는 캐릭터들의 UI배열
    [SerializeField] private DialogData[]   dialogs;    // 현재 분기의 대사 목록 배열

    [SerializeField] 
    private bool    isAutoStart         = true;         // 자동 시작 여부
    private bool    isFirst             = true;         // 최초 1회만 호출하기위한 변수
    private int     currentDialogIndex  = -1;           // 현재 대사 순번
    private int     currentSpeakerIndex = 0;            // 현재 말을 하는 화자의 배열 순번


    private void Awake()
    {
        Setup();
    }

    private void Setup()
    {
        // 모든 대화 관련 게임 오브젝트 비활성화
        for (int i = 0; i < speakers.Length; ++i)
        {
            SetActiveObjects(speakers[i], false);
            // 캐릭터 이미지는 보이도록 설정
            speakers[i].spriteRenderer.gameObject.SetActive(true);
        }
    }

    public bool UpdateDialog()
    {
        // 대사 분기가 시작될 때 1회만 호출
        if (isFirst == true)
        {
            //초기화. 캐릭터 이미지는 활성화하고, 대사 관련 UI는 모두 비활성화
            Setup();

            // 자동 재생(isAutoStart = true) 으로 설정되어 있으면 첫 번째 대사 재생
            if ( isAutoStart )
            {
                SetNextDialog();
                isFirst = false;
            }
        }

        if ( Input.GetMouseButtonDown(0))
        {
            // 대사가 남아있을 경우 다음 대사 진행
            if (dialogs.Length > currentDialogIndex +1)
            {
                SetNextDialog();
            }
            // 대사가 더 이상 없을 경우 모든 오브젝트를 비활성화하고  true 반환
            else
            {
                for( int i = 0; i < speakers.Length; ++i)
                {
                    SetActiveObjects(speakers[i], false);
                    //SetActiveObjects() 에 캐릭터 이미지를 보이지 않게 하는 부분이 없기에 따로 호출
                    speakers[i].spriteRenderer.gameObject.SetActive(false);
                }
                return true; 
            }
        }
        return false;
    }

    private void SetNextDialog()
    {
        //이전 화자의 대화 관련 오브젝트 비활성화
        SetActiveObjects(speakers[currentSpeakerIndex], false);

        //다음 대사를 진행하도록
        currentDialogIndex++;

        //현재 화자 순번 설정
        currentSpeakerIndex = dialogs[currentDialogIndex].speakerIndex;

        //현재 화자의 대화 관련 오브젝트 활성화
        SetActiveObjects(speakers[currentSpeakerIndex], true);

        //현재 화자 이름 텍스트 설정
        speakers[currentSpeakerIndex].textName.text = dialogs[currentDialogIndex].name;

        //현재 화자의 대사 텍스트 설정
        speakers[currentSpeakerIndex].textDialogue.text = dialogs[currentSpeakerIndex].dialogue;
    }

    private void SetActiveObjects(Speaker speaker, bool visible)
    {
        speaker.imageDialog.gameObject.SetActive(visible);
        speaker.textName.gameObject.SetActive(visible);
        speaker.textDialogue.gameObject.SetActive(visible);

        //화살표는 대사가 종료되었을 때만 활성화하기 때문에 항상 false
        speaker.ojjectArrow.SetActive(false);

        //캐릭터 알파 값 변경
        Color color = speaker.spriteRenderer.color;
        color.a = visible == true ? 1 : 0.2f;
        speaker.spriteRenderer.color = color;
    }
}


[System.Serializable]
public struct Speaker
{
    public SpriteRenderer spriteRenderer;     // 캐릭터 이미지(청자/화자 알파값 제어)
    public Image          imageDialog;        // 대화창 Image UiI
    public TextMeshProUGUI textName;            // 현재 대사중인 캐릭터 이름
    public TextMeshProUGUI textDialogue;        // 현재 대사 출력 TextUI
    public GameObject ojjectArrow;              // 대사가 완료되었을 때 출력되는 커서
}


[System.Serializable]
public struct DialogData
{
    public int      speakerIndex;    // 이름과 대사를 출력할 현재 speaekr 의 배열 순번
    public string   name;            // 캐릭터 이름
    [TextArea(3, 5)]
    public string dialogue;          // 대사
}
