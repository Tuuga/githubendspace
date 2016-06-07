using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LinePuzzleActivator : MonoBehaviour {

    public GameObject[] linePuzzlePointsToSetActive;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("collider hit Waypoint Activator");
        foreach (GameObject linePuzzlePoint in linePuzzlePointsToSetActive)
        {
            linePuzzlePoint.GetComponent<LinePuzzlePointInteraction>().SetActive();
        }
    }
}
