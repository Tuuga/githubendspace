using UnityEngine;
using System.Collections;

public class DoorSwitchInteraction : MonoBehaviour, IOnLookInteractable

{
    public Animator activationAnimator;
    public Animator switchAnimator;
    public string triggerEvent;
    public float countdownTime = 2.0f;
    private float timer;
    private bool isOnOver;
    public bool isActive;
    public Material normalMaterial;
    public Material onFocusMaterial;

    private GameObject playerHead;
    GameManager gameManager;
    Renderer knobRenderer;

    // Use this for initialization
    void Start()
    {
        knobRenderer = gameObject.GetComponent<Renderer>();
        knobRenderer.material = normalMaterial;
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
        knobRenderer.material = onFocusMaterial;
    }

    public void OnOut()
    {
        // The reticle on player head is set invisible
        playerHead.GetComponent<ReticleMonocle>().SetInvisible();
        isOnOver = false;
        timer = countdownTime;
        gameManager.HideActivationCursor();
        knobRenderer.material = normalMaterial;
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
            switchAnimator.SetTrigger("turnSwitch");
            activationAnimator.SetBool("isActivated", true);
            
            Fabric.EventManager.Instance.PostEvent(triggerEvent);
            isOnOver = false;
            gameManager.HideActivationCursor();
        }
        if (timer < 0f && isOnOver && !isActive)
        {
            switchAnimator.SetTrigger("turnSwitch");
            Debug.Log("Event trigged. Door Not active!");
            
            Fabric.EventManager.Instance.PostEvent(triggerEvent);
            isOnOver = false;
            gameManager.HideActivationCursor();
        }

    }
}