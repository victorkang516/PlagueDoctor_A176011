using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionUI : MonoBehaviour
{
    Text missionText;
    CanvasGroup canvasGroup;

    bool isShowing = false;

    void Start()
    {
        missionText = transform.GetChild(0).GetComponent<Text>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
    }

    public void Show(string info)
    {
        canvasGroup.alpha = 0;
        missionText.text = info;
        isShowing = true;
    }

    private void Update()
    {
        if (isShowing)
        {
            canvasGroup.alpha += 0.1f;

            if (canvasGroup.alpha >= 1)
                isShowing = false;
        }
    }
}
