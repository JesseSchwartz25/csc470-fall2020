using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerController pc;
    public GameObject Player;


    void Start()
    {
        Player = GameObject.Find("Player");
        pc = Player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pc.LoadLevelTwo)
        {
            LoadLevelTwo();
        }
    }



    public void LoadLevelOne()
    {

        UnityEngine.SceneManagement.SceneManager.LoadScene("LevelOne");
    }

    public void LoadLevelTwo()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("LevelTwo");
    }
}
