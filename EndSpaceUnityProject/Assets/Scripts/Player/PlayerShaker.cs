using UnityEngine;
using System.Collections;

public class PlayerShaker : MonoBehaviour {

    public float Speed;

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(10, 30, 45) * Time.deltaTime * Speed);
    }
}
