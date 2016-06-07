using UnityEngine;
using System.Collections;

public class EngineAudioTriggers : MonoBehaviour {

    public GameObject enginePiston01;
    public GameObject enginePiston02;
    public GameObject enginePiston03;

    public GameObject engineFlywheel01;
    public GameObject engineFlywheel02;


    public GameObject engineCrank01;
    public GameObject engineCrank02;
    public GameObject engineCrank03;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void PlayPiston01()
    {
        enginePiston01.GetComponent<AudioPlay>().playSound();
    }
    public void PlayPiston02()
    {
        enginePiston01.GetComponent<AudioPlay>().playSound();
    }
    public void PlayPiston03()
    {
        enginePiston01.GetComponent<AudioPlay>().playSound();
    }

    public void PlayFlywheel01()
    {
        engineFlywheel01.GetComponent<AudioPlay>().playSound();
    }
    public void PlayFlywheel02()
    {
        engineFlywheel02.GetComponent<AudioPlay>().playSound();
    }

    public void PlayCrank01()
    {
        engineCrank01.GetComponent<AudioPlay>().playSound();
    }
    public void PlayCrank02()
    {
        engineCrank02.GetComponent<AudioPlay>().playSound();
    }
    public void PlayCrank03()
    {
        engineCrank03.GetComponent<AudioPlay>().playSound();
    }

}
