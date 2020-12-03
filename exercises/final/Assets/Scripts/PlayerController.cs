using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public bool attached;
    public float timer = 10f;


    public float Jump;
    public float acrobatics;
    public float test = 69f;
    public CharacterController cc;
    public float gravity = 0f;
    public Vector3 amountToMove;
    public float jumpForwardForce = 0f;

    public GameObject PlayerRotation;
    public GameObject chair;


    void Start()
    {
        chair = this.gameObject;
        Jump = 30f;
        acrobatics = 10f;
        attached = true;
    }


    void Update()
    {

        //gravity and jumpging

        gravity -= 1f * Time.deltaTime;
        if (jumpForwardForce > 0)
            jumpForwardForce -= 1 * Time.deltaTime;


        if (cc.isGrounded || attached)
        {
            gravity = 0;
            jumpForwardForce = 0;
        }
    
        Vector3 grav = new Vector3(0, gravity, 0);
        cc.Move(grav);

        Vector3 airmove = chair.transform.forward * jumpForwardForce * Time.deltaTime;
        cc.Move(airmove);



        //movement
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");
        timer -= Time.deltaTime;


        amountToMove = transform.forward * vAxis * acrobatics * Time.deltaTime + transform.right * hAxis * acrobatics * Time.deltaTime;

        // cc.Move(amountToMove);

        if (attached)
        {
            transform.position = (new Vector3(chair.transform.position.x, transform.position.y, chair.transform.position.z));
        }



        if (timer <= 0 && attached)
        {
            //initiate game over
        }


        if (Input.GetKeyDown(KeyCode.Space) && attached)
        {
            //initiate jump sequence
            attached = false;
            gravity = .35f;
            jumpForwardForce = 10f;
            Debug.Log("jumped");
        }

        if (!attached)
        {
            //movement in the air with wasd --> only do this once chairs are working properly. we need to be able to move until then.
            cc.Move(amountToMove);
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Chair"))
        {
            chair = other.gameObject;
            attached = true;
            timer = 10f;
            //make the player attach to the chair
            Debug.Log("hit chair");

        }

        if (other.CompareTag("Road"))
        {
            //initiate endgame
            Debug.Log("hit road");
        }
    }
}
