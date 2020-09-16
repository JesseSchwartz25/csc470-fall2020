using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	float speed = 8f;
	float rotateSpeed = 120f;
	int score = 0;

	// This value is set in the Unity editor by dragging the Text object
	// into the slot in the inspector.
	public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
	void Update()
	{
		// Rotate on the y axis based on the hAxis value
		// NOTE: If the player isn't pressing left or right, hAxis will be 0 and there 
		// will be no rotation.
		// NOTE: We add the modifer "Space.World" to make it so that the rotation
		// works the way that we expect.
		float hAxis = Input.GetAxis("Horizontal");
		transform.Rotate(0, hAxis * rotateSpeed * Time.deltaTime, 0, Space.World);

		// Move forward
		//transform.position = transform.position + transform.forward * Time.deltaTime;
		// NOTE: We add the modifer "Space.World" to make it so that the movement
		// works the way that we expect (i.e. using the global coordinate system).
		transform.Translate(transform.forward * Time.deltaTime * speed, Space.World);
		
		
		// --- Simulating skateboarding ---
		// Make speed go down over time.
		if (speed > 0) {
			speed -= 4 * Time.deltaTime;
		}
		// Make it so we move faster when we press space
		if (Input.GetKeyDown(KeyCode.Space)) {
			speed += 5;
		}
		// Make sure speed doesn't get less than zero or greater than 15.
		speed = Mathf.Clamp(speed, 0, 15);
	}

	private void OnTriggerEnter(Collider other)
	{
		// "other" is a reference to the collider that we just collided with.
		// Check to see if that object has been tagged with "fries" (you set tags
		// at the top of the inspector when you have a game object selected.
		if (other.gameObject.CompareTag("fries")) {
			// Get a reference to the FryScript on the fries that we just collided with
			FryScript fry = other.gameObject.GetComponent<FryScript>();

			if (!fry.chaseGator) {
				// Set the bool in the FryScript object to true causing the Fries
				// to start chasing the gator (see the Update function in FryScript).
				// Only do this if we aren't already chasing the gator.
				fry.chaseGator = true;

				// Destroy it in 10 seconds
				Destroy(other.gameObject, 10);
			
				// Increment score and update the text UI element (note, we had to import
				// the UI package at the top of the script.
				score++;
				scoreText.text = score.ToString();
			}
		}
	}
	
}
