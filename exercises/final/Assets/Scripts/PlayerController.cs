using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{

    public bool attached;
    public float timer = 10f;


    public float Jump;
    public float acrobatics;
    //public float test = 69f;
    public CharacterController cc;
    public float gravity = 0f;
    public Vector3 amountToMove;
    public float jumpForwardForce = 0f;
    public float currentSpeed;
    public Vector3 oldLocation;
    public float speedtimer;

    public GameObject PlayerRotation;
    public GameObject chair;
    public GameManager gm;
    public TextMeshProUGUI GameUI;
    public int points;


    public int lives;


    void Start()
    {
        // chair = this.gameObject;
        gm = GameManager.instance;
       

        Jump = gm.jumpHeight;

        if (acrobatics < 10)
            acrobatics = 10f;

        attached = false;
        speedtimer = .1f;
        lives = 3;
        
        chair = GameObject.Find("EliteChairLogic");
        points = 0;


        // gm.jumpHeight = Jump;
        //gm.acrobatics = acrobatics;
        acrobatics = gm.acrobatics;

        
    }


    void Update()
    {

        Jump = gm.jumpHeight;
        if (Jump < .35f)
            Jump = .35f;


        points += (int)(-transform.position.y + 2)/3;
        Mathf.Clamp(points, 0, Mathf.Infinity);
        if (points < 0)
            points = 0;

        GameUI.text = "Lives: " + lives + "          Coins: " + gm.coins + "          Points: " + points;
        
        //tracking the current speed of the player by using the old location and the current location vvv

        speedtimer -= Time.deltaTime;


        if(speedtimer <= 0)
        {
            currentSpeed = transform.position.z - oldLocation.z;
            Mathf.Clamp(currentSpeed, 0, 1000);

            oldLocation = transform.position;

            speedtimer = .1f;
        }


       

        acrobatics = gm.acrobatics;



        //gravity and jumping vvv

        gravity -= 1f * Time.deltaTime;
        if (jumpForwardForce > 0)
            jumpForwardForce -= 1 * Time.deltaTime;


        if (cc.isGrounded)
        {
            gravity = 0;
            jumpForwardForce = 0;


            if (lives == 0)
            {
                gm.reloadGame();
            }
        }
    
        Vector3 grav = new Vector3(0, gravity, 0);
        cc.Move(grav);


        Vector3 airmove = (chair.GetComponent<ChairScript>().correctForwardForce * jumpForwardForce * Time.deltaTime) + (transform.forward * currentSpeed * 2 * Time.deltaTime);
        cc.Move(airmove);

        //chair.transform.forward --> took this out for "correctForwardForce" I think it generally works better...
        //it uses the last state of the chair when it was attached. probably not the most efficient to run this every frame but watcha gonna do?

        //movement vvv

        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");
        timer -= Time.deltaTime;


        amountToMove = transform.forward * vAxis * acrobatics * Time.deltaTime + transform.right * hAxis * 2 * acrobatics * Time.deltaTime;

        // cc.Move(amountToMove);

        if (attached)
        {

            chair.GetComponent<ChairScript>().rotationSpeed += hAxis * 100 * Time.deltaTime;
            transform.position = (new Vector3(chair.transform.position.x, transform.position.y, chair.transform.position.z));
           

            if (chair.CompareTag("EliteChair"))
            {
                PlayerRotation.transform.Rotate(0, hAxis * 100 * Time.deltaTime, 0);
            }
            else
            {
                PlayerRotation.transform.rotation = chair.transform.rotation;
            }
        }




        if (Input.GetKeyDown(KeyCode.Space) && attached)
        {
            //initiate jump sequence vvv

            bounce();

            //moved into a seperate method so it could be used elsewhere!

            //attached = false;
            //gravity = .35f;
            //jumpForwardForce = 11f;
            //Debug.Log("jumped");
        }

        if (!attached)
        {
            //movement in the air with wasd --> only do this once chairs are working properly. we need to be able to move until then.
            cc.Move(amountToMove);
        }
    }


    public void bounce()
    {
        attached = false;
        gravity = Jump;
        jumpForwardForce = 11f;
        Debug.Log("jumped");
    }

    public void bounceForward()
    {
        attached = false;
        gravity = Jump;
        Debug.Log("ejected");
    }


    private void OnTriggerEnter(Collider other)
    {
        if ((other.CompareTag("Chair") || other.CompareTag("EliteChair")) && !attached)
        {
           // Destroy(chair);
            chair = other.gameObject;
            attached = true;
            points *= 2;
            //timer = 10f; --> abandoned this idea
            //make the player attach to the chair
            Debug.Log("hit chair");
            if(lives < 3)
                lives++;

        }

        if (other.CompareTag("Road"))
        {
            other.GetComponent<AudioSource>().Play();
            //initiate endgame
            Debug.Log("hit road");
            jumpForwardForce = 0;
            gravity = 0;

            points /= (4-lives);

            Debug.Log(lives + "lives left");

            if (lives == 0)
            {
                //initiate endgame
                gm.reloadGame();
            }
            bounce();
            lives--;
        }

        if (other.CompareTag("NewRoad"))
        {
            gm.BuildNewRoad();
            Destroy(other);
        }


        if (other.CompareTag("Obstacle"))
        {
            other.GetComponent<AudioSource>().Play();
            Debug.Log("hit car");
            bounce();

        }

        if (other.CompareTag("Coin"))
        {
            gm.coins++;
            points *= 2;
            other.GetComponent<AudioSource>().Play();
            Destroy(other);
            other.gameObject.GetComponentInChildren<MeshRenderer>().forceRenderingOff = true;
        }

        if (other.CompareTag("Respawn"))
        {
            gm.reloadGame();
        }

    }

    private void OnTriggerStay(Collider other)
    {

        //moved this from enter to make sure it works when it fucks up for some reason
        if (other.CompareTag("Road"))
        {
            bounce();
           // points /= (4 - lives);
        }
    }
}
