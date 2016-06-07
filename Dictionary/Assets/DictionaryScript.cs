using UnityEngine;
using System.Collections;
using System.Collections.Generic; 
public class DictionaryScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Dictionary<string, int> pb = new Dictionary<string, int>();
        pb.Add("Miksa", 050100123);
        pb.Add("Johnny", 04512345);
        if (pb.ContainsKey("Miksa")) {
            print("Miksa löytyy"); 
        }
        if (pb.ContainsKey("Miksa")) {
            print(pb["Miksa"]);
        }
        pb.Remove("Miksa");
        print("Miksa poistettu");
        
	}
}
