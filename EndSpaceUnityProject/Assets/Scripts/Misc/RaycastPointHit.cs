using UnityEngine;
using System.Collections;

public class RaycastPointHit : MonoBehaviour
{
    public float hitForce;

    void Update()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

       if (Physics.Raycast(ray, out hit))
        {
            if (hit.rigidbody != null)

                hit.rigidbody.AddForceAtPosition(ray.direction * hitForce, hit.point);
         }
    }
}