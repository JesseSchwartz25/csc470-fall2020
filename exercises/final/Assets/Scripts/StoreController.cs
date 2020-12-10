using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StoreController : MonoBehaviour
{


    int jumpcost;
    int acroCost;
    int luckCost;

    public TextMeshProUGUI Coins;
    public TextMeshProUGUI JumpCost;
    public TextMeshProUGUI AirCost;
    public TextMeshProUGUI LuckCost;


    // Start is called before the first frame update
    void Start()
    {
        jumpcost = GameManager.instance.jumpcost;
        acroCost = GameManager.instance.acroCost;
        luckCost = GameManager.instance.luckCost;
    }

    private void OnLevelWasLoaded(int level)
    {
        jumpcost = GameManager.instance.jumpcost;
        acroCost = GameManager.instance.acroCost;
        luckCost = GameManager.instance.luckCost;
    }

    // Update is called once per frame
    void Update()
    {
        Coins.text = "" + GameManager.instance.coins;
        JumpCost.text = "" + jumpcost;
        AirCost.text = "" + acroCost;
        LuckCost.text = "" + luckCost;
    }

    public void JumpHeight()
    {
        if(GameManager.instance.coins >= jumpcost)
        {
            GameManager.instance.jumpHeight *= 1.1f;
            GameManager.instance.coins -= jumpcost;
            GameManager.instance.jumpcost ++;
            jumpcost++;
        }
       

    }

    public void AirControl()
    {
        if (GameManager.instance.coins >= acroCost)
        {
            GameManager.instance.acrobatics *= 1.1f;
            GameManager.instance.coins -= acroCost;
            GameManager.instance.acroCost ++;
            acroCost++;
        }
    }

    public void Luck()
    {
        if (GameManager.instance.coins >= luckCost)
        {
            GameManager.instance.luck++;
            GameManager.instance.coins -= luckCost;
            GameManager.instance.luckCost ++;
            luckCost++;
        }
    }

    public void reloadGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("TitleStore");
    }


}
