using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaypointActivator : MonoBehaviour {

    public bool toBeInactivated;

    public GameObject[] waypointsToSetActive;
    public GameObject[] interactiveObjectsToSetActive;

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("collider hit Waypoint Activator");
        foreach (GameObject waypoint in waypointsToSetActive)
        {
            waypoint.GetComponent<WaypointInteraction>().SetActive();
        }
        foreach (GameObject interactiveObject in interactiveObjectsToSetActive)
        {
            interactiveObject.GetComponent<Collider>().enabled = true;
        }
        if (toBeInactivated)
        {
            gameObject.SetActive(false);
        }
    }

    void OnTriggerExit(Collider other)
    {
        foreach (GameObject interactiveObject in interactiveObjectsToSetActive)
        {
            interactiveObject.GetComponent<Collider>().enabled = false;
        }
    }
}
