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
    public GameObject oldRoad;
    public GameObject ancientRoad;
    public GameObject carObstacle;
    public GameObject regularChair;
    public GameObject eliteChair;
    public PlayerController pc;

    public float gameTimer;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        //ancientRoad = null;
        carObstacle = GameObject.Find("CarLogic");
        regularChair = GameObject.Find("BasicChairLogic");
        eliteChair = GameObject.Find("EliteChairLogic");
        pc = Player.GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
        //endless creation of road vvv



        //enable clicking a canvas while game is not running to activate a store vvv



        //store allows you to sell coins for increased attributes vvv


        //exit the store to reenter the start screen vvv
        
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
        float frequency = Random.Range(0, 4);

        Vector3 startPos = carObstacle.transform.position;

        for(int i = 0; i<frequency; i++)
        {
            Vector3 spawnCar = new Vector3(xPos, yPos / frequency, zPos / frequency) + carObstacle.transform.position;
            xPos = Random.Range(-10f, 10f);
            spawnCar.x = xPos;
            spawnCar.z += 19.4f * 2f;
            spawnCar.y += -1.708f * 2f;

            while(spawnCar.z < Player.transform.position.z)
            {
                //this should fix the cars spawning behind the player

                spawnCar.z += 97f;
                spawnCar.y -= 8.54f;
            }

            //spawn the cars
            carObstacle = Instantiate(carObstacle, spawnCar, carObstacle.transform.rotation);

        }

        spawnChairs();
       
    }

    public void spawnChairs()
    {
        float xPos = 0;
        float yPos = -8.54f;
        float zPos = 97f;
        float frequency = Random.Range(4, 9);

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
            xPos = Random.Range(-10f, 10f);
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
    }

    public void reloadGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }
}
