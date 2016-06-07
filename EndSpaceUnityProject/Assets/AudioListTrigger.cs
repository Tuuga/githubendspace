using UnityEngine;
using System.Collections;

public class AudioLIstTrigger : MonoBehaviour {
    public AudioSource[] sounds; // luodaan lista audiosourceista, listan nimi on sound.
    public float power; // poweri


    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        Rigidbody rb = GetComponent<Rigidbody>();


        if (Input.GetKeyDown(KeyCode.Return)) { // return näppäimellä
            int index = Random.Range(0, sounds.Length); // luodaan random Int arvo, joka on jotain väliltä nolla ja listan pituus. sounds on listan nimi ja lenght sen pituus.
            rb.AddForce(Vector3.up * power, ForceMode.Impulse); // rigibodylle rb annetaan ylöspäin suuntautuvalle vektorille poweria forcemode impulsella.

        }
        if (Input.GetKeyDown(KeyCode.LeftArrow)) { // left arrow näppäimellä
            int index = Random.Range(0, sounds.Length);
            rb.AddForce(Vector3.left * power, ForceMode.Impulse);


        }
        if (Input.GetKeyDown(KeyCode.RightArrow)) { // right arrow näppäimellä
            int index = Random.Range(0, sounds.Length);
            rb.AddForce(Vector3.right * power, ForceMode.Impulse);



        }

    }
    void OnCollisionEnter(Collision c) {
        int index = Random.Range(0, sounds.Length); // luodaan random Int arvo, joka on jotain väliltä nolla ja listan pituus. sounds on listan nimi ja lenght sen pituus.
        sounds[index].Play();
    }
}

