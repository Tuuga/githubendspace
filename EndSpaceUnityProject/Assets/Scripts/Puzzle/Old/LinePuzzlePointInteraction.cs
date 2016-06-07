using UnityEngine;
using System.Collections;

public class LinePuzzlePointInteraction : MonoBehaviour, IOnLookInteractable
{
    public Transform startPoint;
    public Transform endPoint;
    public float maxDistance;

    public float countdownTime = 2.0f;

    private bool isOnOver;
    private bool isActive;
    private float timer;
    public GameObject player;
    private GameObject playerHead;
    private bool isLineActive;
    LineRenderer puzzleLine;
    private GameObject LinePuzzleManager;

    void Start()
    {
        timer = countdownTime;
        playerHead = GameObject.Find("PlayerHead");     
        LinePuzzleManager = GameObject.Find("LinePuzzleManagerOld");
    }

    public void SetActive()
    {
        isActive = true;
        //SetVisible();
        
    }

    public void SetInactive()
    {
        isActive = false;
        isLineActive = false;
        puzzleLine = GetComponent<LineRenderer>();
        puzzleLine.enabled = false;
        SetInvisible();
    }

    public void OnOver()
    {
        SetActive();
        isOnOver = true;
        LinePuzzleManager.GetComponent<LinePuzzleManagerOld>().AddActiveLinePuzzlePointToList(gameObject);
    }

    public void OnOut()
    {
        // The reticle on player head is set invisible
        playerHead.GetComponent<ReticleMonocle>().SetInvisible();
        isOnOver = false;
        timer = countdownTime;
    }

    public void DrawLine()
    {
        puzzleLine = GetComponent<LineRenderer>();
        puzzleLine.SetWidth(.2f, .2f);
        puzzleLine.enabled = true;
        isLineActive = true;
        
        LinePuzzleManager.GetComponent<LinePuzzleManagerOld>().SetLineBetweenPoints();
    }

    void SetInvisible()
    {
//        waypointCentre.SetActive(false);
    }
    void SetVisible()
    {
//        waypointCentre.SetActive(true);
    }

    public void SetEndPoint(Transform newEndPoint)
    {
        endPoint = newEndPoint;
    }

    void Update()
    {
        if (isOnOver && isActive)
        {
            // The reticle on player head is set visible
            playerHead.GetComponent<ReticleMonocle>().SetVisible();
            //Timer starts
            timer -= Time.deltaTime;
        }
        if (timer < 0f && isActive)
        {
            DrawLine();  
        }
        if (isLineActive)
        {
            puzzleLine.SetPosition(0, startPoint.position);
            puzzleLine.SetPosition(1 , endPoint.position);
        }

        float dist = Vector3.Distance(startPoint.position, endPoint.position);
        //print("Distance to other: " + dist);

        if (maxDistance < dist)
        {
            LinePuzzleManager.GetComponent<LinePuzzleManagerOld>().SetLinePuzzlePointInactive();
        }
    }
}
