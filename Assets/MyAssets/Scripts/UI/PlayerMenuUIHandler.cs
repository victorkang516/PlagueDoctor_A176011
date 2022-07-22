using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMenuUIHandler : MonoBehaviour
{
    public bool isShowing = false;

    public GameObject cinematicFreeLook;

    private Button resumeButton;
    private Button exitButton;
    private PlayerController playerController;

    void Awake()
    {
        //cinematicFreeLook = GameObject.Find("CM FreeLook1");

        resumeButton = GameObject.Find("ResumeButton").GetComponent<Button>();
        resumeButton.onClick.AddListener(ResumeGame);

        exitButton = GameObject.Find("ExitButton").GetComponent<Button>();
        exitButton.onClick.AddListener(ExitGame);

        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    public void PauseGame()
    {
        gameObject.SetActive(true);
        isShowing = true;

        Cursor.lockState = CursorLockMode.None;
        cinematicFreeLook.SetActive(false);

        playerController.isPaused = true;
    }

    public void ResumeGame()
    {
        gameObject.SetActive(false);
        isShowing = false;

        Cursor.lockState = CursorLockMode.Locked;
        cinematicFreeLook.SetActive(true);

        playerController.isPaused = false;
    }

    void ExitGame ()
    {
        Application.Quit();
    }
}
