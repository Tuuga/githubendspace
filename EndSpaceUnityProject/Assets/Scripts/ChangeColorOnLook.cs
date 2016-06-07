using UnityEngine;
using System.Collections;

public class ChangeColorOnLook : MonoBehaviour, IOnLookInteractable {

public void OnOver()
    {
        GetComponent<Renderer>().material.color = Color.red;
    }

public void OnOut()
    {
        GetComponent<Renderer>().material.color = Color.blue;
    }
}
