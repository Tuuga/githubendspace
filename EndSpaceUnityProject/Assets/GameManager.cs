using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour {

    
    public GameObject outerCircleObject;
    private RectTransform outerCircle;

    public void SetActivationCursor(Vector2 position, float activationPercent)
    {
        outerCircleObject.SetActive(true);
        
        outerCircle.position = position;
        var sizeScale = new Vector2(activationPercent + 0.5f, activationPercent + 0.5f);
        outerCircle.localScale = sizeScale;
    }

    public void HideActivationCursor()
    {
        outerCircleObject.SetActive(false);
    }

    // Use this for initialization
    void Awake () {
        outerCircle = outerCircleObject.GetComponent<RectTransform>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("space"))
        {
            SceneManager.LoadScene(0);
        }
	
	}
}
