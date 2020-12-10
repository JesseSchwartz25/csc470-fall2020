using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairScript : MonoBehaviour
{

    public GameObject Player;
    public PlayerController pc;
    public GameObject PlayerRotation;
    public Rigidbody rb;
    public bool attached;
    public bool eject;
    public bool toDestroy;
    public Quaternion amountToRotate;
    public bool isElite;


    public Vector3 correctForwardForce;
    //bonus feature: rotation speed is based on jump distance.


    public float rotationSpeed;
    Coroutine destroyCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        pc = Player.GetComponent<PlayerController>();
        //PlayerRotation = Player.Pla
        eject = false;
        attached = false;
        toDestroy = false;

        rotationSpeed = Random.Range(80f, 200f);

        if (gameObject.CompareTag("EliteChair")) 
        {
            Debug.Log(" I am elite");
            isElite = true;
        }

        rb = GetComponent<Rigidbody>();


       

    }

    // Update is called once per frame
    void Update()
    {

        if(!pc.attached && attached)
        {
            //ejection
            Debug.Log("left trigger via if");
            attached = false;
            eject = true;
        }

        if (attached && !isElite)
        {
            transform.Rotate(0, rotationSpeed * Time.deltaTime, 0, Space.Self);
            //PlayerRotation.transform.Rotate(0, rotationSpeed * Time.deltaTime, 0, Space.Self);
            //moved this to the playerscript

        }
        if (attached)
        {
            correctForwardForce = transform.forward;
        }

        if (eject)
        {
            destroyCoroutine = StartCoroutine(DestroyChair());
            rb.AddForce(transform.forward * -1 * 20);
            DestroyChair();
        }
        if (toDestroy)
        {
            //come back to this once the rest of the game works. would be nice to get rid of all of the clutter


           // Player.GetComponent<PlayerController>().chair = Player;
           // Destroy(gameObject);
            //Debug.Log("destroyed");
        }




    }

    IEnumerator DestroyChair()
    {
        
        //Debug.Log("destroy the chair");
        yield return new WaitForSeconds(3);
        toDestroy = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //rotation
            attached = true;
            rb.AddForce(PlayerRotation.transform.forward * pc.jumpForwardForce * 10);
            rb.AddForce(Player.transform.forward * 20f * (10f * pc.currentSpeed));
        }

        if (other.CompareTag("Respawn")){
            Destroy(this);
        }
    }


    //replaced by if statement above which works much faster for some reason. something to do with trigger hitboxes

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        //ejection
    //        Debug.Log("left trigger");
    //        attached = false;
    //        eject = true;
    //    }
    //}

    private void OnBecameInvisible()
    {
        if (eject)
        {
            Destroy(gameObject);
        }
    }
}
