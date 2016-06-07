using UnityEngine;
using System.Collections;

public class ObjectMover : MonoBehaviour {

    public float Speed;
    public bool isActive;
    public Transform playerReticle;

    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;

    // Use this for initialization
    void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            //transform.Translate(new Vector3(0, 0, 0) * Time.deltaTime * Speed);
            Vector3 targetPosition = playerReticle.TransformPoint(new Vector3(0, 0, 0));
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }
}
