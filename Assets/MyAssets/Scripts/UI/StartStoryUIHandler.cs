using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartStoryUIHandler : MonoBehaviour
{
    GameObject page1;
    GameObject page2;
    GameObject page3;

    Button nextButton1;
    Button nextButton2;
    Button startButton;

    CanvasGroup currentCanvasGroup = null;

    bool isShowing = false;

    void Start()
    {
        page1 = GameObject.Find("Page1");
        page2 = GameObject.Find("Page2");
        page3 = GameObject.Find("Page3");

        

        nextButton1 = GameObject.Find("NextButton1").GetComponent<Button>();
        nextButton2 = GameObject.Find("NextButton2").GetComponent<Button>();
        startButton = GameObject.Find("StartButton").GetComponent<Button>();

        nextButton1.onClick.AddListener(GoToSecondPage);
        nextButton2.onClick.AddListener(GoToLastPage);
        startButton.onClick.AddListener(EnterGameScene);

        GoToFirstPage();
    }

    void GoToFirstPage()
    {
        page1.SetActive(true);
        page2.SetActive(false);
        page3.SetActive(false);

        currentCanvasGroup = page1.GetComponent<CanvasGroup>();
        currentCanvasGroup.alpha = 0;

        Show();
    }

    void GoToSecondPage()
    {
        page1.SetActive(false);
        page2.SetActive(true);

        currentCanvasGroup = page2.GetComponent<CanvasGroup>();
        currentCanvasGroup.alpha = 0;

        Show();
    }

    void GoToLastPage()
    {
        page2.SetActive(false);
        page3.SetActive(true);

        currentCanvasGroup = page3.GetComponent<CanvasGroup>();
        currentCanvasGroup.alpha = 0;

        Show();
    }

    void EnterGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void Show()
    {
        isShowing = true;
    }

    private void Update()
    {
        if (isShowing && currentCanvasGroup != null)
        {
            currentCanvasGroup.alpha += 0.05f;

            if (currentCanvasGroup.alpha >= 1)
                isShowing = false;
        }
    }
}
