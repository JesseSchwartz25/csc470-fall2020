using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FryScript : MonoBehaviour
{
	public bool chaseGator = false;
	GameObject gator;
	
    // Start is called before the first frame update
    void Start()
    {
    	// Get a reference to the player (gator).
		gator = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
    	// In the PlayerController script, we set chaseGator to true when the
    	// gator collides with a fries.
        if (chaseGator) {
        	// Compute the vector to the gator and normalize it.
        	// We do this by subtracting our position (the fry's) from the destination's
        	// position (the gator).
			Vector3 directionToGator = gator.transform.position - transform.position;
			directionToGator = directionToGator.normalized;
			
			// Move toward the gator.
			transform.Translate(directionToGator * Time.deltaTime * 6);
		}
	}
}
