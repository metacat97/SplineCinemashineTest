using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class BlinkImage : MonoBehaviour
{
    [SerializeField] 
    private float fadeTime;  //���̵� �Ǵ� �ð�
    private Image fadeImage; //���̵� ȿ���� ���Ǵ� �̹���
   // private Coroutine fadeInOut;
    private void Awake()
    {
        fadeImage = GetComponent<Image>();
        //fadeInOut = StartCoroutine(FadeInOut());
    }

    private void OnEnable()
    {
        StartCoroutine(FadeInOut());
    }

    private void OnDisable()
    { 
        //StopCoroutine(fadeInOut);
        StopCoroutine(FadeInOut()); 
    }

    private IEnumerator FadeInOut()
    {
        while(true) 
        {
            yield return StartCoroutine(Fade(1, 0));
         
            yield return StartCoroutine(Fade(0, 1));
        }
    }

    private IEnumerator Fade(float start, float end)
    {
        float current = 0;
        float percent = 0;

        while (percent < 1)
        {
            current += Time.deltaTime;
            percent = current / fadeTime;

            Color color = fadeImage.color;
            color.a = Mathf.Lerp(start, end, percent);
            fadeImage.color = color;

            yield return null;
        }

    }
}
