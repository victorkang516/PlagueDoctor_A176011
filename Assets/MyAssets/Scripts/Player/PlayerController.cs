using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    //public CharacterController controller;

    //public Transform cam;

    //public float speed = 6f;

    //public float turnSmoothTime = 0.1f;
    //float turnSmoothVelocity;

    public Animator playerAnimator;

    public ParticleSystem curedEffect;
    public ParticleSystem statsIncreaseEffect;
    

    // Attack
    private GameObject hitBox;
    private bool isAttacking = false;

    // Managers
    private GameManager gameManager;

    //Player
    PlayerStats playerStats;

    // UI Handlers
    public bool isPaused = false;

    private PlayerMenuUIHandler playerMenuUIHandler;

    private GameObject interactionUI;
    private GameObject pointedObject;
    private GameObject statIncreaseUI;
    private GameObject winGameUI;

    void Start()
    {
        playerStats = GetComponent<PlayerStats>();

        hitBox = transform.GetChild(3).gameObject;
        hitBox.SetActive(false);

        interactionUI = GameObject.Find("InteractionUI");
        interactionUI.SetActive(false);
        statIncreaseUI = GameObject.Find("StatsIncreaseUI");

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        playerMenuUIHandler = GameObject.Find("PlayerMenuUI").GetComponent<PlayerMenuUIHandler>();
        playerMenuUIHandler.ResumeGame();

        winGameUI = GameObject.Find("WinGameUI");
        winGameUI.SetActive(false);
    }

    void Update()
    {
        HandlePlayerMenu();

        if (isPaused)
            return;

        Attack();
        HandleMovement();
        InteractionRay();
        InteractWithObject();
        
    }

    void Attack ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!isAttacking)
            {
                GetComponent<AudioSource>().Play();
                isAttacking = true;
                StartCoroutine(Attacking());
            }
        }
        
    }

    IEnumerator Attacking()
    {
        playerAnimator.Play("Attack", 0, 0.0f);
        yield return new WaitForSeconds(0.4f);

        hitBox.SetActive(true);
        yield return new WaitForSeconds(0.1f);

        hitBox.SetActive(false);

        isAttacking = false;

        StopAllCoroutines();
    }

    void HandleMovement()
    {
        //float horizontal = Input.GetAxisRaw("Horizontal");
        //float vertical = Input.GetAxisRaw("Vertical");
        //Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        //if(direction.magnitude >= 0.1f)
        //{
        //    float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
        //    float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        //    transform.rotation = Quaternion.Euler(0f, angle, 0f);

        //    Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        //    controller.Move(moveDir.normalized * speed * Time.deltaTime);
        //}
    }

    void InteractionRay ()
    {
        Ray ray = Camera.main.ViewportPointToRay(Vector3.one / 2f);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 10))
        {
            Interactable interactable = hit.collider.GetComponent<Interactable>();

            if (interactable != null)
            {
                pointedObject = hit.collider.gameObject;

                if (!pointedObject.GetComponent<Interactable>().isInteractable)
                    return;

                if (pointedObject.CompareTag("Chest"))
                    interactionUI.GetComponent<InteractionUI>().Show("Open Chest");
                else if (pointedObject.CompareTag("Peasant"))
                    interactionUI.GetComponent<InteractionUI>().Show("Cure");
                else if (pointedObject.CompareTag("Priest"))
                    interactionUI.GetComponent<InteractionUI>().Show("Cure");
                else if (pointedObject.CompareTag("Switch"))
                    interactionUI.GetComponent<InteractionUI>().Show("Trigger Switch");
                else if (pointedObject.CompareTag("Elixir"))
                    interactionUI.GetComponent<InteractionUI>().Show("Keep Elixir");

            }
            else
            {
                interactionUI.GetComponent<InteractionUI>().Hide();
            }
        }
        else
        {
            interactionUI.GetComponent<InteractionUI>().Hide();
        }
    }

    void InteractWithObject()
    {
        if (Input.GetButton("E") && pointedObject != null)
        {
            if (pointedObject.GetComponent<Interactable>().isInteractable)
            {
                if (pointedObject.CompareTag("Chest"))
                {
                    pointedObject.GetComponent<ObjectInteractionAnim>().PlayAnimation();
                    pointedObject.GetComponent<Interactable>().isInteractable = false;
                    statIncreaseUI.GetComponent<StatsIncreaseUI>().Show("Damage +1");
                    interactionUI.GetComponent<InteractionUI>().Hide();

                    hitBox.GetComponent<PlayerHitBox>().IncreaseHitDamage();
                }
                else if (pointedObject.name == "Switch1")
                {
                    pointedObject.GetComponent<ObjectInteractionAnim>().PlayAnimation();
                    pointedObject.GetComponent<Interactable>().isInteractable = false;
                    gameManager.OpenFirstDoor();
                    interactionUI.GetComponent<InteractionUI>().Hide();
                }
                else if (pointedObject.name == "Switch2")
                {
                    pointedObject.GetComponent<ObjectInteractionAnim>().PlayAnimation();
                    pointedObject.GetComponent<Interactable>().isInteractable = false;
                    gameManager.CloseFirstDoor();
                    interactionUI.GetComponent<InteractionUI>().Hide();
                }
                else if (pointedObject.name == "Switch3")
                {
                    pointedObject.GetComponent<ObjectInteractionAnim>().PlayAnimation();
                    pointedObject.GetComponent<Interactable>().isInteractable = false;
                    gameManager.OpenSecondDoor();
                    interactionUI.GetComponent<InteractionUI>().Hide();
                }
                else if (pointedObject.name == "Elixir")
                {
                    WinGame();
                }


                if (pointedObject.CompareTag("Peasant"))
                {
                    StartCoroutine(ShowCuredEffect());
                    pointedObject.GetComponent<Interactable>().isInteractable = false;
                    playerAnimator.Play("Cure", 0, 0.0f);
                    interactionUI.GetComponent<InteractionUI>().Hide();
                }
                
                if (pointedObject.CompareTag("Priest"))
                {
                    StartCoroutine(ShowCuredEffect2());
                    pointedObject.GetComponent<Interactable>().isInteractable = false;
                    
                    playerAnimator.Play("Cure", 0, 0.0f);
                    interactionUI.GetComponent<InteractionUI>().Hide();
                }
            }
        }
    }

    IEnumerator ShowCuredEffect ()
    {
        yield return new WaitForSeconds(1.0f);
        playerStats.GetHeal(5);

        pointedObject.GetComponent<Interactable>().PlayThankYou();
        Instantiate(curedEffect, pointedObject.transform.position + new Vector3(0, 1f, 0), pointedObject.transform.rotation);

        StopAllCoroutines();
    }

    IEnumerator ShowCuredEffect2()
    {
        yield return new WaitForSeconds(1.0f);
        playerStats.GetHeal(10);
        playerStats.ResetHealth();

        pointedObject.GetComponent<Interactable>().PlayThankYou();
        Instantiate(curedEffect, pointedObject.transform.position + new Vector3(0, 1f, 0), pointedObject.transform.rotation);

        StopAllCoroutines();
    }

    void HandlePlayerMenu ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            if(playerMenuUIHandler.isShowing)
            {
                playerMenuUIHandler.ResumeGame();
            }
            else
            {
                playerMenuUIHandler.PauseGame();
            }
    }

    void WinGame ()
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("EndStoryScene");
    }
}
