
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script requires you to have setup your animator with 3 parameters, "InputMagnitude", "InputX", "InputZ"
//With a blend tree to control the inputmagnitude and allow blending between animations.
[RequireComponent(typeof(CharacterController))]
public class MovementInput : MonoBehaviour {

    public float Velocity;
    [Space]

	public float InputX;
	public float InputZ;
	public Vector3 desiredMoveDirection;
	public bool blockRotationPlayer = false;
	public float desiredRotationSpeed = 0.1f;
	public Animator anim;
	public float Speed;
	public float allowPlayerRotation = 0.1f;
	public Camera cam;
	public CharacterController controller;
	public bool isGrounded;

    [Header("Animation Smoothing")]
    [Range(0, 1f)]
    public float HorizontalAnimSmoothTime = 0.2f;
    [Range(0, 1f)]
    public float VerticalAnimTime = 0.2f;
    [Range(0,1f)]
    public float StartAnimTime = 0.3f;
    [Range(0, 1f)]
    public float StopAnimTime = 0.15f;

    public float verticalVel;
    private Vector3 moveVector;

	public float jumpForce = 7f;	
	public float jumpMultiplier = 2.5f;
	public bool onGravityPad = false;
	private AudioSource walkAudio;
	[SerializeField] private float footStepInterval = 0.01f;
	private float footStepTimer;
	

	// Use this for initialization
	void Start () {
		anim = this.GetComponent<Animator>();
		cam = Camera.main;
		controller = this.GetComponent<CharacterController> ();
		walkAudio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		InputMagnitude ();
		
		// check to see if character is grounded
        isGrounded = controller.isGrounded;
        if (isGrounded && verticalVel < 0)
        {
            verticalVel = -2f;
        }

		// jump if space bar is pressed
		if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
		{
			//Debug.Log("Jump!");
			verticalVel = jumpForce * (onGravityPad ? jumpMultiplier : 1f);
			anim.Play("Jump");

		}
		
		verticalVel += Physics.gravity.y * Time.deltaTime;

        moveVector = new Vector3(0, verticalVel, 0);
        controller.Move(moveVector * Time.deltaTime);

		// foot steps audio
		bool isWalking = controller.velocity.magnitude > 0.01f && controller.isGrounded;

		if(isWalking)
		{
			footStepTimer -= Time.deltaTime;
			if(footStepTimer <= 0)
			{
				walkAudio.Play();
				//Debug.Log("Step audio started");
				footStepTimer = footStepInterval;
			}
		}
		else
		{
			footStepTimer = 0;
		}
    }

    void PlayerMoveAndRotation() {
		InputX = Input.GetAxis ("Horizontal");
		InputZ = Input.GetAxis ("Vertical");

		var camera = Camera.main;
		var forward = cam.transform.forward;
		var right = cam.transform.right;

		forward.y = 0f;
		right.y = 0f;

		forward.Normalize ();
		right.Normalize ();

		desiredMoveDirection = forward * InputZ + right * InputX;

        controller.Move(desiredMoveDirection * Time.deltaTime * Velocity);

		/*/ start walk audio if not already playing
		if(isGrounded && !walkAudio.isPlaying)
		{
			walkAudio.Play();
		}*/
		
	}

    public void LookAt(Vector3 pos)
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(pos), desiredRotationSpeed);
		Application.targetFrameRate = 60; 
    }

    public void RotateToCamera(Transform t)
    {

        var camera = Camera.main;
        var forward = cam.transform.forward;
        var right = cam.transform.right;

        desiredMoveDirection = forward;

        t.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredMoveDirection), desiredRotationSpeed);
    }

	void InputMagnitude() {
		//Calculate Input Vectors
		InputX = Input.GetAxis ("Horizontal");
		InputZ = Input.GetAxis ("Vertical");

		//anim.SetFloat ("InputZ", InputZ, VerticalAnimTime, Time.deltaTime * 2f);
		//anim.SetFloat ("InputX", InputX, HorizontalAnimSmoothTime, Time.deltaTime * 2f);

		//Calculate the Input Magnitude
		Speed = new Vector2(InputX, InputZ).sqrMagnitude;

        //Physically move player

		if (Speed > allowPlayerRotation) {
			anim.SetFloat ("Blend", Speed, StartAnimTime, Time.deltaTime);
			PlayerMoveAndRotation ();
		} else if (Speed < allowPlayerRotation) {
			anim.SetFloat ("Blend", Speed, StopAnimTime, Time.deltaTime);
/*
			// if walk audio is playing, stop it
			if(walkAudio.isPlaying)
			{
				walkAudio.Stop();
			} */
		}
	}
	//add physics interaction for seesaw & block
	private void OnControllerColliderHit(ControllerColliderHit hit)
	{
		Rigidbody rb = hit.collider.attachedRigidbody;

		if (rb == null || rb.isKinematic)
			return;
		//prevent up/down movement
		Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

		rb.AddForce(pushDir * Velocity, ForceMode.Impulse);
	}

	// foot steps sound
	public void playFootStep()
	{
		// checked to see if character is on the ground
		if(!isGrounded)
		{
			return;
		}

		walkAudio.Play();

	}
}
