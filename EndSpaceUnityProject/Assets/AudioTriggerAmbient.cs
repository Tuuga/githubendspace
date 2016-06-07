using UnityEngine;
using System.Collections;

public class AudioTriggerAmbient : MonoBehaviour {

    public AudioSource sounds;
    public float fadeInTime;
    public float fadeOutTime;
    private bool isInside;
    private float fOutTime;

    void OnTriggerEnter(Collider other)
    {
        //int index = Random.Range(0, sounds.Length);
        sounds.Play();
        isInside = true;
    }

    void OnTriggerExit(Collider other)
    {
        isInside = false;
    }

    void FixedUpdate()
    {
        if (!isInside) {
               sounds.volume -= fadeOutTime * Time.fixedDeltaTime;
            }
        if (isInside)
        {
            sounds.volume += fadeOutTime * Time.fixedDeltaTime;
        }
    }
    }

