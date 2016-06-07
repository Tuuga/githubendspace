using UnityEngine;
using System.Collections;

public class PuzzleMiddlePoint : MonoBehaviour, IOnLookInteractable
{
    public GameObject linePuzzleStartPoint;
    private bool isOnOver;
    private GameObject playerHead;

    // Use this for initialization
    void Start () {
        playerHead = GameObject.Find("PlayerHead");
    }

    public void OnOver()
    {
        //SetActive();
        isOnOver = true;
        playerHead.GetComponent<ReticleMonocle>().SetVisible();
        linePuzzleStartPoint.GetComponent<LinePuzzleStartPointInteraction>().AddLinePuzzlePointToList(transform.position);
    }

    public void OnOut()
    {
        // The reticle on player head is set invisible
        playerHead.GetComponent<ReticleMonocle>().SetInvisible();
        isOnOver = false;
    }

	// Update is called once per frame
	void Update () {
	
	}
}
