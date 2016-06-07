using UnityEngine;
using System.Collections;

public class ReticleMonocle : MonoBehaviour {

    Rect reticleMonocleRect;
    public Texture reticleMonocleTexture;
    private bool isVisible = false;

	// Use this for initialization
	void Start () {
        float reticleMonocleSize = Screen.width * 0.01f;
        reticleMonocleRect = new Rect(Screen.width / 2 - reticleMonocleSize / 2, Screen.height / 2 - reticleMonocleSize / 2, reticleMonocleSize, reticleMonocleSize);
	}
	
    public void SetVisible()
    {
        isVisible = true;
    }

    public void SetInvisible()
    {
        isVisible = false;
    }

    // 
    void OnGUI () {
        if (isVisible)
        {
            GUI.DrawTexture(reticleMonocleRect, reticleMonocleTexture);
        }
	}
}
