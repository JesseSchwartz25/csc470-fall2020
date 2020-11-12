using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachScript : MonoBehaviour
{
    // Start is called before the first frame update


    //public Renderer rend;
    public Material touching;
    public Material regular;
    public Material conjoined;
    public bool attached = false;
    public bool collided = false;
    public bool hover;
    public GameObject player;
    private MeshRenderer meshRenderer;
    PlayerController pc;
    CharacterController cc;
    GameObject toAttach;


    List<GameObject> attachedto = new List<GameObject>();

    Rigidbody rb;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        meshRenderer = GetComponentInChildren<MeshRenderer>();
        pc = player.GetComponent<PlayerController>();
        cc = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {

        float gravity = 0f;

        gravity -= 9.81f * Time.deltaTime;
        Vector3 grav = new Vector3(0, gravity, 0);
        cc.Move(grav);
        if (cc.isGrounded)
            gravity = 0;

        if (!collided)
        {
            attached = false;
        }
        if (!attached)
        {



        }
        if (attached)
        {
            collided = true;
            GetComponent<BoxCollider>().isTrigger = false;

            Vector3 toMove = pc.amountToMove;

            cc.Move(toMove);

            if (!cc.isGrounded)
            {
                //detach();
            }

        }
        else
        {
            GetComponent<BoxCollider>().isTrigger = true;
        }

        
    }






    private void OnMouseEnter()
    {
        hover = true;
    }

    private void OnMouseExit()
    {
        hover = false;
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
    


            if (attached) 
            {
                meshRenderer.material = touching;
                
            }


            collided = true; 


            Debug.Log(collided); 
        }


        if (other.CompareTag("Player"))
        {
            if (!attached)
            {
                this.meshRenderer.material = touching;
                collided = true;
                Debug.Log(collided);
            }
        }

        



    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            if (!attached)
            {
                meshRenderer.material = regular;
            }


            if (!attached)
            {
                collided = false;
            }
            else
            {
                collided = true;
            }



            Debug.Log(collided);
        }

        if (other.CompareTag("Player") && attached && !collided)
        {
            detach();
            Debug.Log("trigger detach");
        }
    }







    private void OnMouseDown()
    {

        bool todo = false;
        //to join
        if (collided && hover && !attached && !todo && !pc.isLinked)
        {

            attach();

            todo = true;
            

        }
        else if (hover && attached && !todo && pc.isLinked)
        {

            detach();


            Debug.Log("mouse detach");
        }
    }


    public void detach()
    {
        
       // transform.SetParent(null);
        meshRenderer.material = regular;
        gameObject.tag = "Add";
        attached = false;
        gameObject.GetComponent<BoxCollider>().isTrigger = false;
        pc.isLinked = false;

    }

    public void attach()
    {
        attached = true;
        pc.isLinked = true;
      //  transform.SetParent(player.transform);
        meshRenderer.material = conjoined;
        gameObject.tag = "Player";

        gameObject.GetComponent<BoxCollider>().isTrigger = true;


        Debug.Log("attached");
    }
}

