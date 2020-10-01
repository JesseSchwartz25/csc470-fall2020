using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    int speed = 5;
    public int counter = 0;
    public Rigidbody rb = new Rigidbody();
    bool canJump = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(transform.forward * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(transform.forward * Time.deltaTime * -1 * speed);
        }
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rb.AddForce(0, 200, 0);
            canJump = false;
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        canJump = true;
        //counter++;
        Debug.Log(counter);
    }
}
