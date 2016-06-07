using UnityEngine;
using System.Collections;

public class OnLookTriggerAnimation : MonoBehaviour, IOnLookInteractable

{
    public Animator activationAnimator;
    public string triggerEvent;
    public float countdownTime = 2.0f;
    private float timer;
    private bool isOnOver;
    public bool isActive;

    private GameObject playerHead;
    GameManager gameManager;


    // Use this for initialization
    void Start()
    {
        //isActive = false;
        playerHead = GameObject.Find("PlayerHead");
        timer = countdownTime;
    }

    void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void OnOver()
    {
        isOnOver = true;
    }

    public void OnOut()
    {
        // The reticle on player head is set invisible
        playerHead.GetComponent<ReticleMonocle>().SetInvisible();
        isOnOver = false;
        timer = countdownTime;
        gameManager.HideActivationCursor();
    }

    public void SetActive()
    {
        isActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isOnOver)
        {
            // The reticle on player head is set visible
            playerHead.GetComponent<ReticleMonocle>().SetVisible();
            //Timer starts
            timer -= Time.deltaTime;
            gameManager.SetActivationCursor(Camera.main.WorldToScreenPoint(transform.position), timer);
        }
        if (timer < 0f && isOnOver && isActive)
        {
            activationAnimator.SetBool("isActivated", true);
            Fabric.EventManager.Instance.PostEvent(triggerEvent);
            isOnOver = false;
            gameManager.HideActivationCursor();
        }
        if (timer < 0f && isOnOver && !isActive)
        {
            Debug.Log("Event trigged. Door Not active!");
            Fabric.EventManager.Instance.PostEvent(triggerEvent);
            isOnOver = false;
            gameManager.HideActivationCursor();
        }

    }
}