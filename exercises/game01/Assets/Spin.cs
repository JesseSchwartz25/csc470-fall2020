using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{

    //public GameObject skater;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 spinRight = new Vector3(0, 100, 0);
        Vector3 spinLeft = new Vector3(0, -100, 0);


        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(spinRight * Time.deltaTime);
            Debug.Log("Rotating to the right");
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(spinLeft * Time.deltaTime);
            Debug.Log("Rotating to the left");
        }

    }
}
