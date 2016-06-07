using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

    public float smoothTime = 0.3f;
    public float speed = 0.5f;
    //private Vector3 velocity = Vector3.zero;
    private Vector3 Target;
    

    void Start() {
        Target = transform.position;
    }

    void Update() {
        //transform.position = Vector3.SmoothDamp(transform.position, Target, ref velocity, smoothTime);
        transform.position = Vector3.MoveTowards(transform.position, Target, speed);
    }

    public void SetNewTarget(Vector3 newTarget) {
        Target = newTarget;
    }

}
