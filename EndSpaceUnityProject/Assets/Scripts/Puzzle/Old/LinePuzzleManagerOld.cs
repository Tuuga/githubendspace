using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LinePuzzleManagerOld : MonoBehaviour {

    List<GameObject> activeLinePuzzlePoints = new List<GameObject>();

    public void AddActiveLinePuzzlePointToList(GameObject linepoint)
    {
        activeLinePuzzlePoints.Add(linepoint);
    }

    public void SetLineBetweenPoints()
    {
        int currentPoint = activeLinePuzzlePoints.Count -1;
        int previousPoint = activeLinePuzzlePoints.Count -2;
        Debug.Log(currentPoint);
        Debug.Log(previousPoint);
        if (previousPoint > 0)
        {
            Transform newEndPoint = activeLinePuzzlePoints[previousPoint].transform;
            activeLinePuzzlePoints[currentPoint].GetComponent<LinePuzzlePointInteraction>().SetEndPoint(newEndPoint);
        }
    }

    public void SetLinePuzzlePointInactive()
    {
        foreach (GameObject linePuzzlePoint in activeLinePuzzlePoints)
        {
            linePuzzlePoint.GetComponent<LinePuzzlePointInteraction>().SetInactive();
        }
        activeLinePuzzlePoints.Clear();
    }

}
