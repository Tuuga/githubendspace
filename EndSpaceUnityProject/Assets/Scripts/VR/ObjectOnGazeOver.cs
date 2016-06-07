using System;
using UnityEngine;

namespace VRStandardAssets.Utils
{
public class ObjectOnGazeOver : MonoBehaviour {

    public event Action OnOver;             // Called when the gaze moves over this object
    public event Action OnOut;              // Called when the gaze leaves this object

    protected bool m_IsOver;

    public bool IsOver
    {
        get { return m_IsOver; }              // Is the gaze currently over this object?
    }

    // The below functions are called by the VREyeRaycaster when the appropriate input is detected.
    // They in turn call the appropriate events should they have subscribers.
    public void Over()
    {
        m_IsOver = true;

        if (OnOver != null)
            OnOver();
    }

        public void Out()
        {
            m_IsOver = false;

            if (OnOut != null)
                OnOut();
        }
    }
}
