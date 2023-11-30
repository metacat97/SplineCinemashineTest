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
        if (instance == null) //instance�� null. ��, �ý��ۻ� �����ϰ� ���� ������
        {
            instance = this; //���ڽ��� instance�� �־��ݴϴ�.
            DontDestroyOnLoad(gameObject); //OnLoad(���� �ε� �Ǿ�����) �ڽ��� �ı����� �ʰ� ����
        }
        else
        {
            if (instance != this) //instance�� ���� �ƴ϶�� �̹� instance�� �ϳ� �����ϰ� �ִٴ� �ǹ�
                Destroy(this.gameObject); //�� �̻� �����ϸ� �ȵǴ� ��ü�̴� ��� AWake�� �ڽ��� ����
        }
    }


    public IEnumerator StartDialoge()
    {
        textCountdown.gameObject.SetActive(false);

        //ù ��° ��� �б� ����
        yield return new WaitUntil(() => dialogSystem01.UpdateDialog());

        // ��� �б� ���̿� ���ϴ� �ൿ�� �߰��� �� �ִ�.
        // ĳ���͸� �����̰ų� �������� ȹ���ϴ� ����.. �����  5- 4- 3- 2- 1 
        textCountdown.gameObject.SetActive(true);
        int count = 5;
        while ( count > 0 )
        {
            textCountdown.text = count.ToString();
            count--;

            yield return new WaitForSeconds(1f);
        }
        textCountdown.gameObject.SetActive(false);

        //�ι�° ��� �б� ���� 
        yield return new WaitUntil(() => dialogSystem02.UpdateDialog());

        textCountdown.gameObject.SetActive(true);
        textCountdown.text = "The End";
       
        yield return new WaitForSeconds(2f);

        UnityEditor.EditorApplication.ExitPlaymode();
    }

   
}
