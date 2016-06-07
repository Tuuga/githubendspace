using UnityEngine;
using System.Collections;

public class LinePuzzleEndPoint : MonoBehaviour, IOnLookInteractable
{
    public GameObject linePuzzleStartPoint;
    private bool isOnOver;
    private bool isUsed;

    // Use this for initialization
    void Start () {
        isOnOver = false;
        isUsed = false;
        }

    public void OnOver()
    {
        isOnOver = true;
        if (!isUsed)
        {
            linePuzzleStartPoint.GetComponent<LinePuzzleStartPoint>().SetLastLineOnPlace(transform.position);
        }
        isUsed = true;

    }

    public void OnOut()
    {
        // The reticle on player head is set invisible
        // playerHead.GetComponent<ReticleMonocle>().SetInvisible();
        isOnOver = false;
    }

    // Update is called once per frame
    void Update () {
	
	}
}
