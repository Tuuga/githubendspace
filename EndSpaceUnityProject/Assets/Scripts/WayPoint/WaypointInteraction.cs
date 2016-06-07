using UnityEngine;
using System.Collections;

public class WaypointInteraction : MonoBehaviour, IOnLookInteractable {

    public float countdownTime = 2.0f;
    public GameObject waypointParticleEffect;
    public GameObject waypointActivationParticleEffect;
    public GameObject waypointCentre;
    public Transform nextPosition;
    public string setActiveEvent;
    public string setInactiveEvent;
    private bool isOnOver;
    private bool isActive;
    private float timer;
    public GameObject player;
    private GameObject playerHead;
    private GameObject waypointManager;
    //private Vector3 velocity = Vector3.zero;
    GameManager gameManager;

    void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    void Start() {
        timer = countdownTime;
        playerHead = GameObject.Find("PlayerHead");
        waypointManager = GameObject.Find("WaypointManager");
    }

    public void SetActive() {
        Vector3 ToPlayer = player.transform.position - transform.position;
        float waypointScaling = ToPlayer.magnitude / 5;
        Debug.Log(waypointScaling);

        transform.localScale = new Vector3(waypointScaling, waypointScaling, waypointScaling);

        isActive = true;
        ActivationParticles();
        gameObject.GetComponent<SphereCollider>().enabled = true;
        SetVisible();
        // Add the activated waypoint to waypointmanagers list 
        waypointManager.GetComponent<WaypointManager>().AddActiveWaypointToList(gameObject);
    }

    void ActivationParticles()
    {
        Fabric.EventManager.Instance.PostEvent(setActiveEvent, gameObject);
        Instantiate(waypointActivationParticleEffect, transform.position, Quaternion.Euler(90, 0, 0));
    }

    public void SetInactive() {
        Fabric.EventManager.Instance.PostEvent(setInactiveEvent, gameObject);
        isActive = false;
        gameObject.GetComponent<SphereCollider>().enabled = false;
        SetInvisible();
    }

    void SetAllActiveWaypointsInactive()
    {
        waypointManager.GetComponent<WaypointManager>().SetWaypointsInactive();
    }

    void InactivationParticles()
    {
        Instantiate(waypointParticleEffect, transform.position, Quaternion.Euler(-90, 0, 0));
    }

    public void OnOver() {
        isOnOver = true;
    }

    public void OnOut() {
        // The reticle on player head is set invisible
        playerHead.GetComponent<ReticleMonocle>().SetInvisible();
        isOnOver = false;
        gameManager.HideActivationCursor();
        timer = countdownTime;
    }
    // next position is set for the playercontrol
    void ControlPlayer() {
        player.GetComponent<PlayerControl>().SetNewTarget(nextPosition.position);
    }
    void SetInvisible()
    {
        waypointCentre.SetActive(false);
    }
    void SetVisible()
    {
        waypointCentre.SetActive(true);
    }

    void Update() {


        

        if (isOnOver && isActive)
        {


            // The reticle on player head is set visible
            playerHead.GetComponent<ReticleMonocle>().SetVisible();
            //Timer starts
            timer -= Time.deltaTime;

            gameManager.SetActivationCursor(Camera.main.WorldToScreenPoint(transform.position), timer);
        }
        if (timer < 0f && isActive)
        {
            ControlPlayer();
            InactivationParticles();
            SetAllActiveWaypointsInactive();
            gameManager.HideActivationCursor();
        }
    }
}
