using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LinePuzzleStartPoint : MonoBehaviour, IOnLookInteractable
{
    public Camera mainCamera;
    private Vector3 startPoint;
    public Transform endPoint;
    public float countdownTime = 2.0f;
    public GameObject LineSegment;
    public float maxLenght = 2.0f;

    public string setActiveEvent;
    public string setInactiveEvent;
    public string setPuzzleCompleteEvent;

    public Animator activationAnimator;

    public List<GameObject> linePuzzlePoints;

    private GameObject CurrentLineSegment;
    private float timer;
    private bool isOnOver;
    private bool isActive;
    private bool isLineActive;
    private bool isLineIncomplete;
    private bool isLineCompleted;
    private int activePointCounter;

    public Material activePointMaterial;
    public Material inactivePointMaterial;
    public Renderer centrePoint;

    GameManager gameManager;

    List<GameObject> selectedPoints = new List<GameObject>();
    List<GameObject> activeLineSegments = new List<GameObject>();

    private GameObject playerHead;

    // Use this for initialization

    void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Start () {
        centrePoint.material = activePointMaterial;
        isActive = true;
        timer = countdownTime;
        startPoint = transform.position;
        isLineIncomplete = false;
        playerHead = GameObject.Find("PlayerHead");
    }

    public void OnOver()
    {
        isOnOver = true;
        if (isActive) {
        playerHead.GetComponent<ReticleMonocle>().SetVisible();
        }
    }

    public void OnOut()
    {
        // The reticle on player head is set invisible

        isOnOver = false;
        timer = countdownTime;
        playerHead.GetComponent<ReticleMonocle>().SetInvisible();
        gameManager.HideActivationCursor();
    }

    public void SetCurrentLineOnPlace(Vector3 newEndPoint)
    {
        if (CurrentLineSegment)
        {
        
        CurrentLineSegment.GetComponent<LinePuzzleSegment>().SetTarget(newEndPoint, startPoint);
        startPoint = newEndPoint;
        activePointCounter++;
        DrawLine();
        }
    }

    public void SetLastLineOnPlace(Vector3 newEndPoint)
    {
        if (CurrentLineSegment)
        {
            CurrentLineSegment.GetComponent<LinePuzzleSegment>().SetTarget(newEndPoint, startPoint);
            isLineActive = false;
            activePointCounter++;
            // If line is complete
            if (activePointCounter == linePuzzlePoints.Count && !isLineCompleted)
            {
                isLineCompleted = true;
            }
            // If line is incomplete
            if (activePointCounter != linePuzzlePoints.Count && !isLineCompleted)
            {
                isLineIncomplete = true;
            }
        }
    }

    public void DrawLine()
    {
        CurrentLineSegment = (GameObject)Instantiate(LineSegment, startPoint, Quaternion.identity);
        AddActiveLineSegmentToList(CurrentLineSegment);
    }

    // LinePuzzle Segments added to list
    void AddActiveLineSegmentToList(GameObject lineSegment)
    {
        activeLineSegments.Add(lineSegment);
    }

    // Selected point added to list
    public void AddSelectedPointToList (GameObject selectedPoint)
    {
        selectedPoints.Add(selectedPoint);
    }

    // LinePuzzlePoints activated
    void ActivateLinePuzzlePoints()
    {
        foreach (GameObject linePuzzlePoint in linePuzzlePoints)
        {
            linePuzzlePoint.GetComponent<LinePuzzlePoint>().ActivatePoint();
        }
    }

    // reset the linepuzzle 
    public void SetLineSegmentsInactive()
    {
        activePointCounter = 0;
        foreach (GameObject linePuzzlePoint in linePuzzlePoints)
        {
            linePuzzlePoint.GetComponent<LinePuzzlePoint>().ResetPoint();
        }

        foreach (GameObject lineSegment in activeLineSegments)
        {
            lineSegment.GetComponent<LinePuzzleSegment>().SetInactive();
        }

        Fabric.EventManager.Instance.PostEvent(setInactiveEvent);
        activeLineSegments.Clear();
        selectedPoints.Clear();
        isLineActive = false;
        startPoint = transform.position;
        //centrePoint.material = inactivePointMaterial;
        isLineIncomplete = false;
        timer = countdownTime;
    }

    void PuzzleComplete()
    {
        //activationAnimator.SetBool("isActivated", true);
        
        foreach (GameObject linePuzzlePoint in linePuzzlePoints)
        {
            linePuzzlePoint.GetComponent<LinePuzzlePoint>().InactivatePoint();
        }

        foreach (GameObject lineSegment in activeLineSegments)
        {
            lineSegment.GetComponent<LinePuzzleSegment>().SetInactive();
        }

        GetComponent<LinePuzzleComplete>().OnActivate();

        Fabric.EventManager.Instance.PostEvent(setPuzzleCompleteEvent);
        isActive = false;
    }

    static bool isLinesCrossing(Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4)
    {
        Vector2 a = p2 - p1;
        Vector2 b = p3 - p4;
        Vector2 c = p1 - p3;

        float alphaNumerator = b.y * c.x - b.x * c.y;
        float alphaDenominator = a.y * b.x - a.x * b.y;
        float betaNumerator = a.x * c.y - a.y * c.x;
        float betaDenominator = alphaDenominator; /*2013/07/05, fix by Deniz*/

        bool doIntersect = true;

        if (alphaDenominator == 0 || betaDenominator == 0)
        {
            doIntersect = false;
        }
        else
        {

            if (alphaDenominator > 0)
            {
                if (alphaNumerator < 0 || alphaNumerator > alphaDenominator)
                {
                    doIntersect = false;
                }
            }
            else if (alphaNumerator > 0 || alphaNumerator < alphaDenominator)
            {
                doIntersect = false;
            }

            if (doIntersect && betaDenominator > 0)
            {
                if (betaNumerator < 0 || betaNumerator > betaDenominator)
                {
                    doIntersect = false;
                }
            }
            else if (betaNumerator > 0 || betaNumerator < betaDenominator)
            {
                doIntersect = false;
            }
        }

        return doIntersect;
    }

    // Update is called once per frame
    void Update () {
        if (!isActive) return; // TODO -isActive tests

        if (isOnOver && !isLineActive && isActive)
        {
            // The reticle on player head is set visible
            // playerHead.GetComponent<ReticleMonocle>().SetVisible();
            //Timer starts
            timer -= Time.deltaTime;
            gameManager.SetActivationCursor(Camera.main.WorldToScreenPoint(transform.position), timer);
        }
        if (timer < 0f && !isLineActive && isActive)
        {
            DrawLine();
            centrePoint.material = activePointMaterial;
            AddSelectedPointToList(gameObject);
            ActivateLinePuzzlePoints();
            Fabric.EventManager.Instance.PostEvent(setActiveEvent);
            isLineActive = true;
            timer = countdownTime;
            gameManager.HideActivationCursor();
        }
        if (isLineActive)
        {
            CurrentLineSegment.GetComponent<LinePuzzleSegment>().SetTarget(endPoint.position, startPoint);
        }
        if (CurrentLineSegment &&
            CurrentLineSegment.GetComponent<LinePuzzleSegment>().currentLength > maxLenght) {
            SetLineSegmentsInactive();
        }
        if (isLineIncomplete)
        {
            timer -= Time.deltaTime;
            if (timer < 0f)
            {
                SetLineSegmentsInactive();
            }
        }
        if (isLineActive && !isLineIncomplete && !isLineCompleted && selectedPoints.Count > 2)
        {
            Vector2 targetPoint = mainCamera.WorldToScreenPoint(endPoint.transform.position);
            /*for (int i = 0; i < selectedPoints.Count; i++) {
                Vector2 selectedPoint2D = mainCamera.WorldToScreenPoint(selectedPoints[i].transform.position);
                
            }*/

            Vector2 selectedPoint2D1 = mainCamera.WorldToScreenPoint(selectedPoints[0].transform.position);
            Vector2 selectedPoint2D2 = mainCamera.WorldToScreenPoint(selectedPoints[1].transform.position);
            Vector2 selectedPoint2D3 = mainCamera.WorldToScreenPoint(selectedPoints[2].transform.position);

            //Debug.Log("pisteitä on");

            if (isLinesCrossing(selectedPoint2D1, selectedPoint2D2, selectedPoint2D3, targetPoint))
            {
                SetLineSegmentsInactive();
            }

        }
        if (isLineCompleted && isActive)
        {
            timer -= Time.deltaTime;
            if (timer < 0f)
            {
                PuzzleComplete();
            }
        }


    }
}
