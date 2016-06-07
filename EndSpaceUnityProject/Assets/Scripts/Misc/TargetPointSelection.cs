using UnityEngine;
using System.Collections;

public class TargetPointSelection : MonoBehaviour
{

    public bool Select = false;
    public Color selectedColor = Color.blue;
    public Color selectedHighlightColor = Color.blue;
    public Color highlightColor = Color.red;
    Renderer meshRenderer;
    Color originalColor;
    public bool isSelected;
    public float selectionTimer = 2.0F;
    private float selectionCounter;

    // Use this for initialization
    void Start()
    {
        selectionCounter = selectionTimer;
        meshRenderer = GetComponentInChildren<Renderer>();
        originalColor = meshRenderer.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Select)
        {
            selectionCounter = selectionTimer;
            if (!isSelected)
            {
                meshRenderer.material.color = originalColor;
            }
            if (isSelected)
            {
                meshRenderer.material.color = selectedColor;
            }
        }
        if (Select && !isSelected)
        {
            selectionCounter -= Time.deltaTime;
            meshRenderer.material.color = highlightColor;
        }
        if (Select && isSelected)
        {
            selectionCounter -= Time.deltaTime;
            meshRenderer.material.color = selectedHighlightColor;
        }
        if (selectionCounter < 0.0f && !isSelected && Select)
        {
            selectionCounter = selectionTimer;
            isSelected = true;

        }
        if (selectionCounter < 0.0f && isSelected && Select)
        {
            selectionCounter = selectionTimer;
            isSelected = false;

        }
    }
}