using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;

public class PuzzleDrawLine : MonoBehaviour {

    [SerializeField] private VREyeRaycaster m_VREyeRaycaster;

    public Transform startPoint;
    public Transform endPoint;
    public Transform reticle;
    public bool isActive;
    LineRenderer puzzleLine;
    
    // Use this for initialization
    void Start () {
        puzzleLine = GetComponent<LineRenderer>();
        puzzleLine.enabled = false;
        puzzleLine.SetWidth(.2f, .2f);
	}
    // Viivanpiirto lopetetaan
    public void RemoveLine()
    {   
        puzzleLine = GetComponent<LineRenderer>();
        puzzleLine.SetWidth(.2f, .2f);
        puzzleLine.enabled = false;
        isActive = false;
    }
    // Jos pelaaja katsoo viivaa piirrettäessä toiseen nodeen viiva piirretään näiden välille
    public void LineComplete()
    {
        endPoint = m_VREyeRaycaster.CurrentInteractible.transform;
        puzzleLine = GetComponent<LineRenderer>();
        puzzleLine.SetWidth(.2f, .2f);
        puzzleLine.enabled = true;
        puzzleLine.SetPosition(0, startPoint.position);
        puzzleLine.SetPosition(1, endPoint.position);
        //deaktivoidaan viivanpiirto aloituspisteen ja pelaajan kohdistimen välille
        isActive = false;
    }
    //viivan piirto aloitetaan 
    public void DrawLine () {
        puzzleLine = GetComponent<LineRenderer>();
        endPoint = reticle;
        puzzleLine.SetWidth(.2f, .2f);
        puzzleLine.enabled = true;
        isActive = true;
    }

	// Update is called once per frame
	void Update () {

        //jos viivan piirto on aktiivinen se piirretään aloituspisteen ja kohdistimen välille.
        if (isActive)
        {
            puzzleLine.SetPosition(0, startPoint.position);
            puzzleLine.SetPosition(1, reticle.position);
        }
	}
}
