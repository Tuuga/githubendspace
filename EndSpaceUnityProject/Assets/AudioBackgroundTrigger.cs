using UnityEngine;
using System.Collections;

public class AudioBackgroundTrigger : MonoBehaviour {

    public string fadeInEvent;
    public string fadeOutEvent;

    void OnTriggerEnter ()
    {
        Fabric.EventManager.Instance.PostEvent(fadeInEvent);
    }

    void OnTriggerExit()
    {
        Fabric.EventManager.Instance.PostEvent(fadeOutEvent);
    }
}
