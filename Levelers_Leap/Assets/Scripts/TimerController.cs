using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimerController : MonoBehaviour
{
    // Public Variables
    public float CountDown;
    public TextMeshProUGUI countDownDisplay;
    public TextMeshProUGUI deathText;
    public GameObject Player;
    public GameObject CameraObj;
    public GameObject PlayerCam;
    public CharacterController playerController; 

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
        if (countdownStarted)
        {
            // Count down
            currentTime -= Time.deltaTime;

            DisplayTime(currentTime);
        }

        if (playerIn && currentTime <= 0)
        {
            StartCoroutine(playerDeath());
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
        countDownDisplay.gameObject.SetActive(false);
        deathText.color = Color.green;
        deathText.text = "Congrats You Have Escaped, right back to where it all started. ";
    }

    void DisplayTime(float timeToDisplay)
    {
        int minutes = Mathf.FloorToInt(timeToDisplay / 60);
        int seconds = Mathf.FloorToInt(timeToDisplay % 60);

        countDownDisplay.text = "Time Left: " + string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    IEnumerator playerDeath()
    {
        // Timer Stopping
        countdownStarted = false;
        countDownDisplay.gameObject.SetActive(false);
        deathText.text = "Times Up You Died";
        PlayerCam.SetActive(false);
        CameraObj.SetActive(true);
        CameraObj.transform.position = PlayerCam.transform.position;

        playerController.gameObject.SetActive(false);

        Destroy(Player);

        yield return new WaitForSeconds(10f);

        // Go Back to Main menu
        SceneManager.LoadScene("MainMenuUI");
    }

}
