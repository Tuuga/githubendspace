using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaypointManager : MonoBehaviour {

    List<GameObject> activeWaypoints = new List<GameObject>();

    public void AddActiveWaypointToList(GameObject waypoint)
    {
        activeWaypoints.Add(waypoint);
    }

    public void SetWaypointsInactive()
    {
        foreach (GameObject waypoint in activeWaypoints)
        {
            waypoint.GetComponent<WaypointInteraction>().SetInactive();
        }
        activeWaypoints.Clear();
        }
    
}
