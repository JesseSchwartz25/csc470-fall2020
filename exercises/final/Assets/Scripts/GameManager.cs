using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{


    public float jumpHeight;
    public float jumpForward;
    public int luck;
    public int coins;
    public float acrobatics;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

        //enable clicking a canvas while game is not running to activate a store
        //store allows you to sell coins for increased attributes
        //exit the store to reenter the start screen
        
    }
}
