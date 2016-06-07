using UnityEngine;
using System.Collections;

public class LinePuzzleComplete : MonoBehaviour, IActivate
{

    public Animator activationAnimator;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnActivate()
    {
        activationAnimator.SetBool("isActivated", true);
        Debug.Log("Door Activated?");
    }
}
