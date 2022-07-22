using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsIncreaseUI : MonoBehaviour
{
    CanvasGroup canvasGroup;
    bool isShowing = false;
    bool isHiding = false;

    Text infoText;

    void Start()
    {
        infoText = transform.GetChild(0).GetComponent<Text>();

        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
    }

    public void Show(string info)
    {
        canvasGroup.alpha = 0;
        infoText.text = info;
        isShowing = true;
        isHiding = false;

        StopAllCoroutines();
    }

    IEnumerator WaitAWhile()
    {
        isShowing = false;
        isHiding = false;

        yield return new WaitForSeconds(2.0f);

        isHiding = true;
    }

    private void Update()
    {
        if (isShowing)
        {
            canvasGroup.alpha += 0.1f;

            if (canvasGroup.alpha >= 1)
                StartCoroutine(WaitAWhile());
        }
        
        if (isHiding)
        {
            canvasGroup.alpha -= 0.1f;

            if (canvasGroup.alpha <= 0)
                isHiding = false;
        }

        
    }

}
