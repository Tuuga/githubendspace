using UnityEngine;
using System.Collections;

public interface IOnLookInteractable
{
    void OnOver();

    void OnOut();
}

public interface IActivate
{
    void OnActivate();
}
