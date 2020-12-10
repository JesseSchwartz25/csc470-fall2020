using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartScreenManager : MonoBehaviour
{

    public TextMeshProUGUI highScore;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        highScore.text = "High Score: " + GameManager.instance.highScore;
    }


    public void reloadGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("TitleStore");
    }

    public void startGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }

    public void loadControls()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Controls");
    }

    //public void loadControls()
    //{
    //    //GameObject SplashScreen = GameObject.Find("SplashScreen");
    //    //GameObject ControlScreen = GameObject.Find("ControlsScreen");
    //    //GameObject StoreScreen = GameObject.Find("StoreScreen");

    //    SplashScreen.SetActive(false);
    //    ControlScreen.SetActive(true);
    //    StoreScreen.SetActive(false);
    //}

    public void backToStart()
    {
        //GameObject SplashScreen = GameObject.Find("SplashScreen");
        //GameObject ControlScreen = GameObject.Find("ControlsScreen");
        //GameObject StoreScreen = GameObject.Find("StoreScreen");

    //    SplashScreen.SetActive(true);
    //    ControlScreen.SetActive(false);
    //    StoreScreen.SetActive(false);
    }

    public void loadStore()
    {
        //  GameObject SplashScreen = GameObject.Find("SplashScreen");
        //   GameObject ControlScreen = GameObject.Find("ControlsScreen");
        //  GameObject StoreScreen = GameObject.Find("StoreScreen");

        UnityEngine.SceneManagement.SceneManager.LoadScene("Store");

        //SplashScreen.SetActive(false);
        //ControlScreen.SetActive(false);
        //StoreScreen.SetActive(true);
    }

}
