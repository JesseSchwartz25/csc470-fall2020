using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class reset : MonoBehaviour
{
    public GameObject enemy;
    public Text timer;

    Vector3 resetPosition;
    public float xPos;
    public float yPos;
    public float zPos;



    // Start is called before the first frame update
    void Start()
    {
        xPos = enemy.transform.position.x;
        yPos = enemy.transform.position.y;
        zPos = enemy.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer.text != "")
        {
            enemy.transform.position = new Vector3(xPos, yPos, zPos);
        }
    }
}
