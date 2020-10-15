using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{


	//for platforming
	float moveSpeed = 30;
	float rotateSpeed = 120f;

	public CharacterController cc;

	bool prevIsGrounded = false;

	float yVelocity = 0;
	float jumpForce = .5f;
	float gravityModifier = 0.1f;

	bool isFlying = false;



	//for flying

	float speed = 10;
	float maxSpeed = 20;
	float forwardSpeed = 6;
	float pitchSpeed = 80;
	float pitchModSpeedRate = 3f;
	float rollSpeed = 80;

	bool hasRotated = false;




	public GameObject robot;
	public GameObject flyingRobot;

	public MovingPlatform PlatformAttachedTo;


	public Text Score;
	public Button Restart;
	public Text Timer;
	int ScoreInt = 1;
	float time = 0f;
	
	// Start is called before the first frame update
	void Start()
	{
		cc = gameObject.GetComponent<CharacterController>();
		flyingRobot.transform.localScale = new Vector3(0, 0, 0);
	}
	
	// Update is called once per frame
	void Update()
	{
		time += Time.deltaTime;


		Timer.text = "" + time;

		if (!isFlying)
		{
			float hAxis = Input.GetAxis("Horizontal");
			float vAxis = Input.GetAxis("Vertical");

			//--- ROTATION ---
			//Rotate on the y axis based on the hAxis value
			//NOTE: If the player isn't pressing left or right, hAxis will be 0 and there will be no rotation
			transform.Rotate(0, hAxis * rotateSpeed * Time.deltaTime, 0);


			//--- DEALING WITH GRAVITY ---
			if (!cc.isGrounded)
			{ //If we go in this block of code, cc.isGrounded is false (that's what the ! does)
			  //If we're not on the ground, apply "gravity" to yVelocity
				yVelocity = yVelocity + Physics.gravity.y * gravityModifier * Time.deltaTime;

				//If we are moving upward (yVelocity > 0), and the player has released the jump button
				//start falling downward (by setting the yVelocity to 0)
				if (Input.GetKeyUp(KeyCode.Space) && yVelocity > 0)
				{
					yVelocity = 0;
				}
			}
			else
			{
				if (!prevIsGrounded)
				{
					//By being in this if statement, we know we JUST landed.
					//NOTE: We know we just landed because cc.isGrounded is true (meaning
					//		on the last cc.Move() call we collided with something. This condition also
					//		required previousIsGroundedValue to be false which means we were not colliding
					//		with the ground on the previous Update.

					//Set the yVelocity to zero right when we hit the ground so that we don't accumulate 
					//a bunch of yVelocity. The CharacterController will prevent us from moving through
					//the floor, but we are managing the yVelocity ourselves, so we need to make sure
					//that it is zero when we start to fall. This is where we do that.
					yVelocity = 0;
				}

				//JUMP. When the player presses space, set yVelocity to the jump force. This will immediately
				//make the player start moving upwards, and gravity will start slowing the movement upward
				//and eventually make the player hit the ground (thus landing in the 'if' statment above)
				if (Input.GetKeyDown(KeyCode.Space))
				{
					yVelocity = jumpForce;
				}
			}

			//--- TRANSLATION ---
			//Move the player forward based on the vAxis value
			//NOTE: If the player isn't pressing up or down, vAxis will be 0 and there will be no movement
			//		based on input. However, yVelocity will still move the player downward if they are
			//		not colliding with the ground anymore
			Vector3 amountToMove = transform.forward * vAxis * moveSpeed * Time.deltaTime;

			//Set the amount we move in the y direction to be whatever we have gotten from simulating physics
			amountToMove.y = yVelocity;

			//If we are attached to a platform, move the amount that the platform moved.
			if (PlatformAttachedTo != null)
			{
				amountToMove += PlatformAttachedTo.DistanceMoved;
			}

			//This will move the player according to the forward vector and the yVelocity using the
			//CharacterController.
			cc.Move(amountToMove);

			//Store our current previousIsGroundedValue (so we can do that check to see if we just
			//landed above as described above)
			//NOTE: After cc.Move() is called, cc.isGrounded is updated to relfect whether that Move()
			//		function call collided with the ground.
			prevIsGrounded = cc.isGrounded;
		}
		else
		{

			cc = null;
			//if (!hasRotated ) {
				
			//	robot.transform.Rotate(-90, 0, 0);
			//	hasRotated = true;
			//}


			float hAxis = Input.GetAxis("Horizontal");
			float vAxis = Input.GetAxis("Vertical");

			// Rotate the plane based on input.
			float xRot = vAxis * pitchSpeed * Time.deltaTime;
			float yRot = 0;
				//hAxis * rollSpeed / 4 * Time.deltaTime;
			float zRot = -hAxis * rollSpeed * Time.deltaTime;

			if(transform.rotation.z != 0)
            {
				yRot += -transform.rotation.z / 1;
				Mathf.Clamp(yRot, -90, 90);
				Debug.Log(yRot);
            }

			transform.Rotate(xRot, yRot, zRot, Space.Self);

			// Compute a modifier (forwardSpeed) based on if the plane is looking up or down.
			// If the y value of the tranform's forward is positive, we know we are looking up, 
			// if it is negative, we know we are looking down.
			forwardSpeed += -transform.forward.y * pitchModSpeedRate * Time.deltaTime;
			// Make sure we never to too fast and that forwardSpeed never goes below zero.
			forwardSpeed = Mathf.Clamp(forwardSpeed, 0, 5f);

			// Move forward as modified by forwardSpeed and speed.
			transform.Translate(transform.forward * speed * forwardSpeed * Time.deltaTime, Space.World);

			// If we ever go too slow, turn on the gravity on the rigid body so that the plane falls.
			if (forwardSpeed <= 0.1f)
			{
				yVelocity = yVelocity + Physics.gravity.y * gravityModifier * Time.deltaTime;

			}

			// Make sure we never go below the ground. First, we find out what the height of the terrain is at
			// the position the plane is in. If the plane's y position is below that position, we know we have gone
			// too low. In the if statement, we simply place the plane at the height of the terrain.
			// But this is where you could have the plane crash, or have it slow down, or something.
			float terrainHeight = Terrain.activeTerrain.SampleHeight(transform.position);
			if (transform.position.y < terrainHeight)
			{
				transform.position = new Vector3(transform.position.x, terrainHeight, transform.position.z);
			}

			// Shoot an apple pie whenever the player presses space.
			

			// Position the camera behind and above the player.
			Vector3 cameraPosition = transform.position - transform.forward * 12 + Vector3.up * 5;
			Camera.main.transform.position = cameraPosition;
			Vector3 lookAtPos = transform.position + transform.forward * 8;

			// Rotate the camera so that it looks always in front of the plane.
			Camera.main.transform.LookAt(lookAtPos, Vector3.up);
		}


		
	}



    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Fly"))
        {
			isFlying = true;
			//Debug.Log("should be flying");
			Destroy(other);

			robot.transform.localScale = new Vector3 (0, 0, 0);
			flyingRobot.transform.localScale = new Vector3(1, 1, 1);
        }


        if (other.CompareTag("ring")){
			Score.text = "Score: " + ScoreInt;
			ScoreInt++;
        }
    }
}
