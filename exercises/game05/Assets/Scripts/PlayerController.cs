using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    public Material touching;
    public Material regular;
    public Material conjoined;
    //public bool attached = false;
    //public bool collided = false;
    public bool LoadLevelTwo = false;
    public bool LoadLevelThree = false;

    public bool isLinked = false;

    public CharacterController cc;
    public float moveSpeed = 10f;
    public Vector3 amountToMove;
    float gravity = 0f;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");


        amountToMove = transform.forward * vAxis * moveSpeed * Time.deltaTime + transform.right * hAxis * moveSpeed * Time.deltaTime;

        cc.Move(amountToMove);

        

        gravity -= 1f * Time.deltaTime;
        Vector3 grav = new Vector3(0, gravity, 0);
        cc.Move(grav);
        if (cc.isGrounded) gravity = 0;



    }
    //IDK why but this doesnt really work. it works for changing the color but triggers are easier i feel like.
    //private void OnControllerColliderHit(ControllerColliderHit hit)
    //{
    //    if (hit.collider.gameObject.CompareTag("Add"))
    //    {
    //        MeshRenderer meshRenderer = hit.collider.gameObject.GetComponentInChildren<MeshRenderer>();
    //        meshRenderer.material = touching;


    //        AttachScript aScript = hit.collider.gameObject.GetComponent<AttachScript>();

    //        aScript.collided = true;


    //        Debug.Log(aScript.collided);
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {

        //Moved this to the attachScript so that block can attach to each other
        //    if (other.CompareTag("Add"))
        //    {
        //        AttachScript aScript = other.gameObject.GetComponent<AttachScript>();

        //        MeshRenderer meshRenderer = other.gameObject.GetComponentInChildren<MeshRenderer>();

        //        if (!aScript.attached)
        //        {
        //            meshRenderer.material = touching;
        //        }


        //        aScript.collided = true;


        //        Debug.Log(aScript.collided);
        //    }

        if (other.CompareTag("EndLevelOne"))
        {
            LoadLevelTwo = true;

        }

        if (other.CompareTag("EndLevelTwo"))
        {
            LoadLevelThree = true;
            Debug.Log("end level 2");
        }

        if (other.CompareTag("Jump"))
        {
            gravity = .35f;
        }




    }


    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("Add"))
    //    {
    //        AttachScript aScript = other.gameObject.GetComponent<AttachScript>();

    //        MeshRenderer meshRenderer = other.gameObject.GetComponentInChildren<MeshRenderer>();

    //        if (!aScript.attached)
    //        {
    //            meshRenderer.material = regular;
    //            aScript.collided = false;
    //            aScript.detach();
    //        }

            
            


    //        Debug.Log(aScript.collided);
    //    }
    //}




}
