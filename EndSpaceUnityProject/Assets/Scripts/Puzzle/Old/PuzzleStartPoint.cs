using System;
using System.Collections;
using UnityEngine;
using VRStandardAssets.Utils;

public class PuzzleStartPoint : MonoBehaviour {

    [SerializeField] private SelectionRadial m_SelectionRadial;         // This controls when the selection is complete.
    [SerializeField] private VRInteractiveItem m_VRInteractiveItem;       // The interactive item.
    [SerializeField] private VREyeRaycaster m_VREyeRaycaster;            // 

    private bool m_GazeOver;                                            // Whether the user is looking at the VRInteractiveItem currently.

    public GameObject puzzleStartPoint;

    private void OnEnable()
    {
        m_VRInteractiveItem.OnOver += HandleOver;
        m_VRInteractiveItem.OnOut += HandleOut;
        m_SelectionRadial.OnSelectionComplete += HandleSelectionComplete;
    }

    private void OnDisable()
    {
        m_VRInteractiveItem.OnOver -= HandleOver;
        m_VRInteractiveItem.OnOut -= HandleOut;
        m_SelectionRadial.OnSelectionComplete -= HandleSelectionComplete;
    }

    private void HandleOver()
    {
        // When the user looks at the rendering of the scene, show the radial.
        m_SelectionRadial.Show();
        m_GazeOver = true;
    }

    private void HandleOut()
    {
        // When the user looks away from the rendering of the scene, hide the radial.
        m_SelectionRadial.Hide();
        m_GazeOver = false;
    }

    private void HandleSelectionComplete()
    {
        // If the user is looking at the rendering of the scene when the radial's selection finishes, activate the button.
        if (m_GazeOver)
            ActivateButton();
    }

    private void ActivateButton()
    {
        //kun ajastin on aktivoitunut viivanpiirto funktio kutsutaan viivanpiirto skriptistä
        puzzleStartPoint.GetComponent<PuzzleDrawLine>().DrawLine();
    }
}

