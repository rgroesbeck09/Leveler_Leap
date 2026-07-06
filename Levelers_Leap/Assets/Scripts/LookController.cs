using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookController : MonoBehaviour
{
    // Public vars
    public Transform player;
    public float sensitivityX = 150f;
    public float sensitivityY = 150f;
    public float xRotations = 0f;
    public float yaw = 0f;
    public float pitch = 15f;

    // private vars

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        transform.rotation = Quaternion.Euler(pitch, yaw, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        // debug
        //Debug.Log("MouseLook running");

        float mouseX = Input.GetAxis("Mouse X") * sensitivityX * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivityY * Time.deltaTime;

        xRotations -= mouseY;
        xRotations = Mathf.Clamp(xRotations, -40f, 80f);

        transform.localRotation = Quaternion.Euler(xRotations, 0, 0);

        player.Rotate(Vector3.up * mouseX);
    }
}
