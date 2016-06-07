using UnityEngine;
using System.Collections;

public class RaycastSelect : MonoBehaviour
{
    public GameObject targetPointer;
    private GameObject onLookInteractable;

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit hit;

        Ray ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out hit))
        {
            // if raycast hits anything move the targetpointer
            targetPointer.transform.position = hit.point;

            if (hit.collider.gameObject.GetComponent<IOnLookInteractable>() != null) // If hit object has needed script (avoid highliting other objects)
            {
                if (onLookInteractable != hit.collider.gameObject) // if I`m not already looking at it
                {
                    if (onLookInteractable != null) // if no object selected;
                    {
                        onLookInteractable.GetComponent<IOnLookInteractable>().OnOut(); // Reverse the old one back in here
                    }
                    onLookInteractable = hit.collider.gameObject; // make object my target
                    onLookInteractable.GetComponent<IOnLookInteractable>().OnOver(); // call it`s script
                }
            }
            else if (onLookInteractable != null) // 
            {
                onLookInteractable.GetComponent<IOnLookInteractable>().OnOut(); // Reverse the old one back in here
                onLookInteractable = null;
            }
        }
        else if (onLookInteractable != null) //
        {
            onLookInteractable.GetComponent<IOnLookInteractable>().OnOut(); // Reverse the old one back in here
            onLookInteractable = null;
        }

       
    }
}

