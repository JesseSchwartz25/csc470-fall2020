using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{


    public float jumpHeight;
    public float jumpForward;
    public int luck;
    public int coins;
    public float acrobatics;
    public int highScore;
    public GameObject Player;
    public GameObject oldRoad;
    public GameObject ancientRoad;
    public GameObject carObstacle;
    public GameObject regularChair;
    public GameObject eliteChair;
    public GameObject coinsObject;
    public PlayerController pc;
   

    GameObject SplashScreen;
    GameObject ControlScreen;
    GameObject StoreScreen;


    public float gameTimer;

    public static GameManager instance;



    public int jumpcost =1;
    public int acroCost =1;
    public int luckCost =1;

    private void Awake()
    {
        // The Singleton pattern.
        if (instance != null && instance != this)
        {
            // Enforce that there is only one GameManager.
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        //score = PlayerPrefs.GetInt("score");
    }

    void Start()
    {
        Player = GameObject.Find("Player");
        //ancientRoad = null;
        carObstacle = GameObject.Find("CarLogic");
        regularChair = GameObject.Find("BasicChairLogic");
        eliteChair = GameObject.Find("EliteChairLogic");
        pc = Player.GetComponent<PlayerController>();
        coinsObject = GameObject.Find("Coin");

        //SplashScreen = GameObject.Find("SplashScreen");
        //ControlScreen = GameObject.Find("ControlsScreen");
        //StoreScreen = GameObject.Find("StoreScreen");

        jumpcost = 1;
        acroCost = 1;
        luckCost = 1;

        jumpHeight = .35f;
        acrobatics = 10f;
        highScore = 0;

    }

    private void OnLevelWasLoaded(int level)
    {
        Player = GameObject.Find("Player");
        //ancientRoad = null;
        carObstacle = GameObject.Find("CarLogic");
        regularChair = GameObject.Find("BasicChairLogic");
        eliteChair = GameObject.Find("EliteChairLogic");
        pc = Player.GetComponent<PlayerController>();
        coinsObject = GameObject.Find("Coin");
        oldRoad = GameObject.Find("RoadLogic");


        //SplashScreen = GameObject.Find("SplashScreen");
        //ControlScreen = GameObject.Find("ControlsScreen");
        //StoreScreen = GameObject.Find("StoreScreen");
    }


    void Update()
    {


    }


    public void BuildNewRoad()
    {

        Destroy(ancientRoad);
        ancientRoad = oldRoad;

        Vector3 oldpos = oldRoad.transform.position;
        Vector3 newpos = oldpos + new Vector3(0, -8.54f, 97);

        oldRoad = Instantiate(oldRoad, newpos, oldRoad.transform.rotation);

        SpawnCar();

        


    }


    public void SpawnCar()
    {

        //build the new car's position

        float xPos = 0;
        float yPos = -8.54f;
        float zPos = 97f;
        float frequency = Random.Range(0, 3);

        Vector3 startPos = carObstacle.transform.position;

        for(int i = 0; i<frequency; i++)
        {
            Vector3 spawnCar = new Vector3(xPos, yPos / frequency, zPos / frequency) + carObstacle.transform.position;
            xPos = Random.Range(-10f, 10f);
            spawnCar.x = xPos;
            spawnCar.z += 19.4f;
            spawnCar.y += -1.708f;

            while(spawnCar.z < Player.transform.position.z + 45)
            {
                //this should fix the cars spawning behind the player

                spawnCar.z += 97f / 5f;
                spawnCar.y -= 8.54f / 5f;
            }

            //spawn the cars
            carObstacle = Instantiate(carObstacle, spawnCar, carObstacle.transform.rotation);

            float xChair = spawnCar.x * 2;
            Mathf.Clamp(xChair, - 16f, 16f);

            if(2 > xChair && xChair < -2)
            {
                xChair += 5;
            }

            Instantiate(regularChair, carObstacle.transform.position - new Vector3(xChair, -8.54f / 4 , 97f / 4), carObstacle.transform.rotation);

        }

        spawnChairs();
       
    }

    public void spawnChairs()
    {
        float xPos = 0;
        float yPos = -8.54f;
        float zPos = 97f;
        float frequency = Random.Range(2, 4);

        GameObject chairToSpawn;
        GameObject previousChair = pc.chair;
       


        for (int i = 0; i < frequency; i++)
        {
            //what type of chair will spawn
            int luckRoll = Random.Range(0, 10);

            if (luck > luckRoll)
            {
                chairToSpawn = eliteChair;
            }
            else
            {
                chairToSpawn = regularChair;
            }


            //placing the chairs
            Vector3 spawnChair = new Vector3(xPos, yPos / frequency, zPos / frequency) + previousChair.transform.position;
            xPos = Random.Range(-7f, 7f);
            spawnChair.x = xPos;
            spawnChair.z += 19.4f * 1.5f;
            spawnChair.y += -1.708f * 1.5f;

            while (spawnChair.z < Player.transform.position.z)
            {
                //this should fix the chairs spawning behind the player

                spawnChair.z += 97f;
                spawnChair.y -= 8.54f;
            }
            previousChair = Instantiate(chairToSpawn, spawnChair, carObstacle.transform.rotation);

        }

        spawnCoins();
    }



    public void spawnCoins()
    {
        float xPos = 0;
        float yPos = -8.54f;
        float zPos = 97f;
        float frequency = Random.Range(1, 3);

        GameObject previousCoins = coinsObject;


        for(int i=0; i<frequency; i++)
        {
            Vector3 spawnCoins = new Vector3(xPos, yPos / frequency, zPos / frequency) + coinsObject.transform.position;



            xPos = Random.Range(-10f, 10f);
            spawnCoins.x = xPos;
            spawnCoins.z += 19.4f * 1.5f;
            spawnCoins.y += -1.708f * 1.5f;

            while (spawnCoins.z < Player.transform.position.z)
            {
                //this should fix the chairs spawning behind the player

                spawnCoins.z += 97f;
                spawnCoins.y -= 8.54f;
            }

            coinsObject = Instantiate(coinsObject, spawnCoins, coinsObject.transform.rotation);
        }


       
    }

    public void reloadGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("TitleStore");
        if(pc.points > highScore)
        {
            highScore = pc.points;
        }
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

        SplashScreen.SetActive(true);
        ControlScreen.SetActive(false);
        StoreScreen.SetActive(false);
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





    // vv moved to screenmanager vv

    //public void JumpHeight()
    //{
    //    if (coins > jumpcost)
    //    {
    //        jumpHeight *= 1.25f;
    //        coins -= jumpcost;
    //        jumpcost *= 2;
    //    }


    //}

    //public void AirControl()
    //{
    //    if (coins > acroCost)
    //    {
    //        acrobatics *= 1.25f;
    //        coins -= acroCost;
    //        acroCost *= 2;
    //    }
    //}

    //public void Luck()
    //{
    //    if (coins > luckCost)
    //    {
    //        luck++;
    //        coins -= luckCost;
    //        luckCost *= 2;
    //    }
    //}





}
