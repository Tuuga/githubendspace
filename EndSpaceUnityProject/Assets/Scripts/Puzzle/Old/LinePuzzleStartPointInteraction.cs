using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class LinePuzzleStartPointInteraction : MonoBehaviour, IOnLookInteractable
{
    public Transform startPoint;
    public Transform endPoint;
    public float countdownTime = 2.0f;
    private bool isOnOver;
    private bool isActive;
    private float timer;
    private GameObject playerHead;
    private bool isLineActive;

    List<Vector3> points = new List<Vector3>();

    LineRenderer puzzleLine;
    private GameObject LinePuzzleManager;


    // Adding a middle point to the line
    public void AddLinePuzzlePointToList(Vector3 linepoint)
    {

        points[points.Count-1] = linepoint;
        puzzleLine.SetPosition(points.Count - 1, linepoint);
        points.Add(endPoint.position);
        
        puzzleLine.SetVertexCount(points.Count);

        /*
            lineRenderer.SetVertexCount(pathNodes.length);
    for (var i: int = 0; i < pathNodes.length; i++){
        lineRenderer.SetPosition(i, pathNodes[i].transform.position);
    }*/
    }


    void AddTargetPointerToPuzzlePointsList()
    {
        points.Add(endPoint.position);
        puzzleLine.SetVertexCount(points.Count);
    }

    // Use this for initialization
    void Start () {
        puzzleLine = GetComponent<LineRenderer>();
        timer = countdownTime;
        playerHead = GameObject.Find("PlayerHead");

        points.Add(transform.position);
        puzzleLine.SetVertexCount(1);
        puzzleLine.SetPosition(0,transform.position);
    }

    public void OnOver()
    {

        isOnOver = true;
        playerHead.GetComponent<ReticleMonocle>().SetVisible();
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
        
        puzzleLine.SetWidth(.2f, .2f);
        puzzleLine.enabled = true;
        isLineActive = true;
        AddTargetPointerToPuzzlePointsList();
    }

    // Update is called once per frame
    void Update () {
        if (isOnOver && !isLineActive)
        {
         
            //Timer starts
            timer -= Time.deltaTime;
        }
        if (timer < 0f && !isLineActive)
        {
            DrawLine();
        }
        if (isLineActive)
        {
            puzzleLine.SetPosition(points.Count-1, endPoint.position);
        }
    }
}
