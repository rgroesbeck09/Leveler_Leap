using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerController : MonoBehaviour
{
    // Public Variables
    public float CountDown;
    public ParticleSystem[] explosions;
    public TextMeshProUGUI countDownDisplay;
    public GameObject Player;

    // Private vars
    private bool countdownStarted = false;
    private float currentTime;
    private bool playerIn;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = CountDown;
    }

    // Update is called once per frame
    void Update()
    {
        if (!countdownStarted)
            return;

        // Count down
        currentTime -= Time.deltaTime;
        
        DisplayTime(currentTime);

        Debug.Log("PlayerIn: " + currentTime);

        if (playerIn && currentTime <= 0)
        {
            Destroy(Player);
            StartCoroutine(TimerFinishedBoom());

            // kick off cut scene

        }

    }

    // track the countdown
    private void OnTriggerEnter(Collider other)
    {
        if(!countdownStarted)
        {
            countdownStarted = !countdownStarted;
            playerIn = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // let game know player left
        playerIn = false;
    }

    void DisplayTime(float timeToDisplay)
    {
        int minutes = Mathf.FloorToInt(timeToDisplay / 60);
        int seconds = Mathf.FloorToInt(timeToDisplay % 60);

        countDownDisplay.text = "Time Left: " + string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    IEnumerator TimerFinishedBoom()
    {
        Debug.Log("Time's Up!");

        // explosion time
        foreach (ParticleSystem boom in explosions)
        {
            boom.Play();
            yield return new WaitForSeconds(0.1f);
        }
    }
}
