using System;
using System.Collections;
using UnityEngine;

using VRStandardAssets.Utils;

//namespace VRStandardAssets.Target
//{
    public class NodeActivator : MonoBehaviour
    {
        public Transform targetToMovePlayer;
        public event Action<NodeActivator> OnButtonSelected;        // This event is triggered when the selection of the button has finished.

        [SerializeField] private SelectionRadial m_SelectionRadial;         // This controls when the selection is complete.
        [SerializeField] private VRInteractiveItem m_InteractiveItem;       // The interactive item for where the user should click to load the level.

        private bool m_GazeOver;                                            // Whether the user is looking at the VRInteractiveItem currently.

        private void OnEnable()
        {
            m_InteractiveItem.OnOver += HandleOver;
            m_InteractiveItem.OnOut += HandleOut;
            m_SelectionRadial.OnSelectionComplete += HandleSelectionComplete;
        }

        private void OnDisable()
        {
            m_InteractiveItem.OnOver -= HandleOver;
            m_InteractiveItem.OnOut -= HandleOut;
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
               ActivateButton(); //StartCoroutine
        }
        private void ActivateButton()
        {
            // If anything is subscribed to the OnButtonSelected event, call it.
            if (OnButtonSelected != null)
                OnButtonSelected(this);
            // Set player's next target.            
            HandleOut();
            SetPlayerTarget();
        }
        void SetPlayerTarget()
        {
            GameObject.Find("Player").GetComponent<PlayerMover>().NewTarget = targetToMovePlayer;
            //enabled = false;
        }

}
//}
