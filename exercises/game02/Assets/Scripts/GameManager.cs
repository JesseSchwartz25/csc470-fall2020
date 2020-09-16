using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{


    public Text startText;
    public Button startButton;
    public Text buttonText;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        startText.text = "";
        Destroy(startButton);
        Destroy(buttonText);
    }


}
