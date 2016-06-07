using UnityEngine;
using System.Collections;

public class DestroyAfterTime : MonoBehaviour {

    public float destroyAfterTime = 1.5f;

	// Update is called once per frame
	void Update () {
        Destroy(gameObject, destroyAfterTime);
	}
}
