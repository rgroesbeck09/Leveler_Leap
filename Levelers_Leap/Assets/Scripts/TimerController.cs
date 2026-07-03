using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerController : MonoBehaviour
{
    // Public Variables
    public float CountDown;
    //public ParticleSystem explosion;

    // Private vars
    private bool countdownStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(countdownStarted)
        {
            CountDown = CountDown - 1f;
        }
    }

    // track the countdown
    private void OnTriggerEnter(Collider other)
    {
        if(!countdownStarted)
        {
            countdownStarted = !countdownStarted;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        // Write player death here

    }

    private void OnTriggerExit(Collider other)
    {
        // shut door behind the user

    }
}
