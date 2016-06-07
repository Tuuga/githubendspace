using UnityEngine;
using System.Collections;

public class AudioPlay : MonoBehaviour {
   public string playThisFabricEvent;
    public string playThisFabricEvent01;
    public string playThisFabricEvent02;
    public string playThisFabricEvent03;

    public void playSound() {
        Fabric.EventManager.Instance.PostEvent(playThisFabricEvent, gameObject);
    }
    public void playSound01() {
        Fabric.EventManager.Instance.PostEvent(playThisFabricEvent01, gameObject);
    }
    public void playSound02() {
        Fabric.EventManager.Instance.PostEvent(playThisFabricEvent02, gameObject);
    }
    public void playSound03() {
        Fabric.EventManager.Instance.PostEvent(playThisFabricEvent03, gameObject);
    }
}