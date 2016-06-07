using UnityEngine;
using System.Collections;

public class RoutePointInteraction : MonoBehaviour {

    public Transform nextPosition;
    public GameObject player;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("collider hit RoutePoint");
        player.GetComponent<PlayerControl>().SetNewTarget(nextPosition.position);
    }
}
