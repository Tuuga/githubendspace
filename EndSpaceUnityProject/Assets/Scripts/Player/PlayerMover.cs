using UnityEngine;
using System.Collections;

public class PlayerMover : MonoBehaviour
{
    public Transform NewTarget;

    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        Vector3 targetPosition = NewTarget.position;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

    }

}