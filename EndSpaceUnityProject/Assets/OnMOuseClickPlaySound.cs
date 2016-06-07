using UnityEngine;
using System.Collections;

public class OnMOuseClickPlaySound : MonoBehaviour {



    // Update is called once per frame
    void OnMouseDown() {
        Fabric.EventManager.Instance.PostEvent("ConsoleSwitch");
        print ("ok"); 
    }
    
            }
        

    

