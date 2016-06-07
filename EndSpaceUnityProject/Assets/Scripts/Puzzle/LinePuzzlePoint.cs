using UnityEngine;
using System.Collections;

public class LinePuzzlePoint : MonoBehaviour, IOnLookInteractable
{
    public GameObject linePuzzleStartPoint;
    public bool isEndPoint;
    private bool isOnOver;
    private bool isUsed;
    private bool isActive;

    public string setActiveEvent;
    public string setInactiveEvent;

    public Material activePointMaterial;
    public Material inactivePointMaterial;
    public Renderer centrePoint;

    private GameObject playerHead;

    // Use this for initialization
    void Start()
    {
        isActive = false;
        isOnOver = false;
        isUsed = false;
        playerHead = GameObject.Find("PlayerHead");
    }

    public void OnOver()
    {
        isOnOver = true;
        if (isActive)
        {
            playerHead.GetComponent<ReticleMonocle>().SetVisible();
        }
        if (!isUsed && !isEndPoint && isActive)
        {
            Fabric.EventManager.Instance.PostEvent(setActiveEvent);
            linePuzzleStartPoint.GetComponent<LinePuzzleStartPoint>().SetCurrentLineOnPlace(transform.position);
            linePuzzleStartPoint.GetComponent<LinePuzzleStartPoint>().AddSelectedPointToList(gameObject);
            centrePoint.material = activePointMaterial;
            isUsed = true;
        }
        if (!isUsed && isEndPoint && isActive)
        {
            Fabric.EventManager.Instance.PostEvent(setActiveEvent);
            linePuzzleStartPoint.GetComponent<LinePuzzleStartPoint>().SetLastLineOnPlace(transform.position);
            centrePoint.material = activePointMaterial;
            isUsed = true;
        }
    }

    public void ActivatePoint()
    {
        isActive = true;
        isUsed = false;
        centrePoint.material = inactivePointMaterial;
    }
    
    public void ResetPoint()
    {
        Fabric.EventManager.Instance.PostEvent(setInactiveEvent);
        InactivatePoint();
        centrePoint.material = inactivePointMaterial;
        isUsed = false;
    }

    public void InactivatePoint()
    {
        isActive = false;
    }

    public void OnOut()
    {
        // The reticle on player head is set invisible
        // playerHead.GetComponent<ReticleMonocle>().SetInvisible();
        isOnOver = false;
        playerHead.GetComponent<ReticleMonocle>().SetInvisible();
    }
}
