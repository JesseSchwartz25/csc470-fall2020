using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject player;
    public Button rb;
    public GameObject portal;
    public GameObject mazePosition;
    public GameObject escapePosition;
    public Text timer;
    public Text scoreText;
    public Text startText;



    float speed = 12f;
    float rotateSpeed = 100f;
    int score = 0;
    bool gameStarted = false;
    float transportTimer = 20f;
    float transportRate = 20f;
    bool useTimer = false;
    Quaternion forwardPos;



    // Start is called before the first frame update
    void Start()
    {
        forwardPos = player.transform.rotation;
        
    }

    // Update is called once per frame
    void Update()
    {

        if (gameStarted)
        {
            //these are borrowed from gator fry, its just movement so I dont feel bad.
            //I only want movement once the button is pressed.
            float hAxis = Input.GetAxis("Horizontal");
            transform.Rotate(0, hAxis * rotateSpeed * Time.deltaTime, 0, Space.World);


            if(Input.GetKey(KeyCode.W))
                transform.Translate(transform.forward * Time.deltaTime * speed, Space.World);
        }


        if (useTimer)
        {
            //this will start the maze timer
            transportTimer -= Time.deltaTime;
            timer.text = transportTimer.ToString();

            if(transportTimer <= 0)
            {
                player.transform.position = new Vector3(escapePosition.transform.position.x, escapePosition.transform.position.y, escapePosition.transform.position.z);
                transportTimer = transportRate;
                useTimer = false;
                timer.text = "";

                //set the player's rotate equal to the spotlight
                player.transform.rotation = forwardPos;
                //player.transform.Rotate(escapePosition.transform.forward);
                //player.transform.Rotate(escapePosition.transform.rotation.x, escapePosition.transform.rotation.y, escapePosition.transform.rotation.z);
            }
        }
        




    }



    public void StartGame_movement()
    {
        gameStarted = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "portal" && score != 10)
        {
            //this teleports the player to a position in the middle of the maze
            player.transform.position = new Vector3(mazePosition.transform.position.x, mazePosition.transform.position.y, mazePosition.transform.position.z);
           

            //start the timer
            useTimer = true;

        }

        if (other.tag == "portal" && score == 10)
        {
            startText.text = "You Win!!!!";
            player.transform.position = new Vector3(0, -100, 0);
        }

        if (other.tag == "enemy")
        {
            startText.text = "game over";
            gameStarted = false;
        }

        if(other.tag == "book")
        {
            score++;
            scoreText.text = "Score: " + score;
            //Destroy(other);
            other.transform.Translate(0,-50, 0);
        }


    }
}
