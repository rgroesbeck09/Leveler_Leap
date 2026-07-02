using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerController : MonoBehaviour
{
    // Public Variables
    public float CountDown;
    public ParticleSystem explosion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    // track the countdown
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name + " entered the trigger.");
    }
}
