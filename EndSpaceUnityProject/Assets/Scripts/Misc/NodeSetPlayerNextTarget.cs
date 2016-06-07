using UnityEngine;
using System.Collections;

public class NodeSetPlayerNextTarget : MonoBehaviour
{
    public Transform Target;

    public void SetPlayerTarget()
    {
        GameObject.Find("Player").GetComponent<PlayerMover>().NewTarget = Target;
        gameObject.GetComponent<NodeActivator>().enabled = false;
    }
}