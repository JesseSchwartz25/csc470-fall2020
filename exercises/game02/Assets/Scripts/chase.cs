using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chase : MonoBehaviour
{

    public GameObject enemy;
    public GameObject book;
    GameObject player;
    public Text timer;

    public bool chasePlayer = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("EscapePlayer");

    }

    // Update is called once per frame
    void Update()
    {
        if (chasePlayer && timer.text == "")
        {
            Vector3 dirToPlayer = player.transform.position - enemy.transform.position;
            dirToPlayer = dirToPlayer.normalized;

            enemy.transform.Translate(dirToPlayer * Time.deltaTime * Random.Range(5f, 10f));
        }
     
    }

    private void OnTriggerEnter(Collider other)
    {
        //this will start a librarian chasing the player, hopefully
        chasePlayer = true;
    }


}
