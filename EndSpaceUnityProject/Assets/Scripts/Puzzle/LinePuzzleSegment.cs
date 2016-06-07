using UnityEngine;
using System.Collections;

public class LinePuzzleSegment : MonoBehaviour {

    public float scale = 0.01f;
    public float currentLength;

    void Start()
    {

    }

    public void SetInactive()
    {
        Destroy(gameObject);
    }
	
    public void SetTarget (Vector3 target, Vector3 startPoint)
    {
        Vector3 direction = target - startPoint;
        transform.position = (startPoint + target) / 2;
        transform.rotation = Quaternion.LookRotation(direction);
        transform.localScale = new Vector3(scale, scale, direction.magnitude);
        currentLength = direction.magnitude;
    }

}
