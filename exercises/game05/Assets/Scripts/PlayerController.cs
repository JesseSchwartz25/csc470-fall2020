using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public Text endText;

   



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


    private void OnTriggerEnter(Collider other)
    {

       

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

        if (other.CompareTag("EndLevelThree"))
        {
            endText.transform.localScale = new Vector3(1,1,1);
        }




    }




}
