using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	// These references to prefabs are assigned in the Unity editor.
	public GameObject fryPrefab;
	public GameObject rainDropPrefab;
	
	// As an example, we will use GameObject.Find() to find the GameObject
	// with the name "Ground".
	GameObject ground;
	
	// The makeRainTimer variable will go down everytime Update is called, and 
	// when it becomes less than zero we will instantiate a 'rainDrop' prefab
	// and then reset the makeRainTimer to makeRainRate. 
	float makeRainTimer = 0.01f;
	float makeRainRate = 0.01f;

	int numFries = 0;
	
	// Start is called before the first frame update
	void Start()
	{
		// This is an example of how to 
		ground = GameObject.Find("Ground");
	}
	
	// Update is called once per frame
	void Update()
	{
		// Decrement the timer.
		makeRainTimer -= Time.deltaTime;
		if (makeRainTimer < 0) {
			// If we get in here, it means that makeRainRate amount of time has gone by.
			
			// Create a position to spawn the rainDrop.
			Vector3 pos = new Vector3(ground.transform.position.x + Random.Range(-10, 10)
								, ground.transform.position.y + 50, 
								ground.transform.position.z + Random.Range(-10, 10));
			// Instantiate the rainDrop prefab and store a reference to it in 'drop'.
			GameObject drop = Instantiate(rainDropPrefab, pos, Quaternion.identity);
			// Get the 'renderer' component from drop, and assign a random color to its material.
			Renderer rend = drop.GetComponent<Renderer>();
			rend.material.color = new Color(Random.value, Random.value, Random.value);
			
			// Tell Unity to destroy drop in 5 seconds.
			Destroy(drop, 5f);
			
			// Reset the timer so that in makeRainRate amount of time we will go into this
			// if statement again.
			makeRainTimer = makeRainRate;
		}
	}
	
	public void MakeMoreFries()
	{
		numFries++;

		if (numFries < 10) {
			// This function is called when the "More Fries" UI button is pressed.
			// Find the Button listed under Canvas in Unity, and see how we assign
			// this function to be called when the button is clicked.
			Debug.Log("Make fries");
			// Create a randonm position over ground and instantiate some fries.
			Vector3 pos = new Vector3(ground.transform.position.x + Random.Range(-10, 10)
									, ground.transform.position.y + 10,
									ground.transform.position.z + Random.Range(-10, 10));
			Instantiate(fryPrefab, pos, Quaternion.identity);
		} else {
			// Load level
			SceneManager.LoadScene("level");
		}
	}
}
