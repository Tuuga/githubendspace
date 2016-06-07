using UnityEngine;
using System.Collections;

public class PuzzleDrawLineOld : MonoBehaviour {

    public bool isActive;
    public GameObject reticle;
    public Material puzzleLine;

	// Use this for initialization
	void Start () {
	
	}

    void DrawLine(Vector3 start, Vector3 end, Color color, float duration = 0.02f)
    {
        GameObject myLine = new GameObject();
        myLine.transform.position = start;
        myLine.AddComponent<LineRenderer>();
        LineRenderer lr = myLine.GetComponent<LineRenderer>();
        lr.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
        lr.SetColors(color, color);
        lr.SetWidth(0.1f, 0.1f);
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
        GameObject.Destroy(myLine, duration);
    }

    // Update is called once per frame
    void Update () {
        // jos aktiivinen piirtää viivan kappaleesta kohdistimeen
        if (isActive)
        {
            DrawLine(transform.position, reticle.transform.position, Color.white, 0.02f);
        }
	
	}
}
