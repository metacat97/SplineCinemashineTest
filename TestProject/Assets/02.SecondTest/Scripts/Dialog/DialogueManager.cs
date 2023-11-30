using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance = null;

    [SerializeField] private DialogSystem dialogSystem01;

    [SerializeField] TextMeshProUGUI textCountdown;

    [SerializeField] private DialogSystem dialogSystem02;


    private void Awake()
    {
        if (instance == null) //instance가 null. 즉, 시스템상에 존재하고 있지 않을때
        {
            instance = this; //내자신을 instance로 넣어줍니다.
            DontDestroyOnLoad(gameObject); //OnLoad(씬이 로드 되었을때) 자신을 파괴하지 않고 유지
        }
        else
        {
            if (instance != this) //instance가 내가 아니라면 이미 instance가 하나 존재하고 있다는 의미
                Destroy(this.gameObject); //둘 이상 존재하면 안되는 객체이니 방금 AWake된 자신을 삭제
        }
    }


    public IEnumerator StartDialoge()
    {
        textCountdown.gameObject.SetActive(false);

        //첫 번째 대사 분기 시작
        yield return new WaitUntil(() => dialogSystem01.UpdateDialog());

        // 대사 분기 사이에 원하는 행동을 추가할 수 있다.
        // 캐릭터를 움직이거나 아이템을 획등하는 등의.. 현재는  5- 4- 3- 2- 1 
        textCountdown.gameObject.SetActive(true);
        int count = 5;
        while ( count > 0 )
        {
            textCountdown.text = count.ToString();
            count--;

            yield return new WaitForSeconds(1f);
        }
        textCountdown.gameObject.SetActive(false);

        //두번째 대사 분기 시작 
        yield return new WaitUntil(() => dialogSystem02.UpdateDialog());

        textCountdown.gameObject.SetActive(true);
        textCountdown.text = "The End";
       
        yield return new WaitForSeconds(2f);

        UnityEditor.EditorApplication.ExitPlaymode();
    }

   
}
