using UnityEngine;
using System.Collections;

public class OnLookTrigger : MonoBehaviour, IOnLookInteractable
{

    public string triggerEvent;
    public float countdownTime = 2.0f;
    private float timer;
    private bool isOnOver;
    
    private GameObject playerHead;
    GameManager gameManager;

    void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Use this for initialization
    void Start () {
        playerHead = GameObject.Find("PlayerHead");
        timer = countdownTime;
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

    // Update is called once per frame
    void Update () {
        if (isOnOver)
        {
            // The reticle on player head is set visible
            playerHead.GetComponent<ReticleMonocle>().SetVisible();
            //Timer starts
            timer -= Time.deltaTime;

            gameManager.SetActivationCursor(Camera.main.WorldToScreenPoint(transform.position), timer);
        }
        if (timer < 0f && isOnOver)
        {
            Debug.Log("Event trigged");
            Fabric.EventManager.Instance.PostEvent(triggerEvent);
            isOnOver = false;
            gameManager.HideActivationCursor();
        }

    }
}
