using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GiftPanel : MonoBehaviour
{

    public Text ancientText;
    public Text gemsText;
    public Text coinsText;

    public TextMeshProUGUI Massage;

    public GameObject MassagePanel;
    public GameObject GameOverPanel;

    private int[] countGods = new int[3];
    public static int GodsMassage;

    public int gems;
    public int coins;
    public int ancients;
    private int score_need;

    
    private GameMaster gm;

    void Start()
    {
        GameOverPanel.SetActive(false);
        countGods[0] = 0;
        countGods[1] = 0;
        countGods[2] = 0;
        score_need = 0;
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
    }

    void Update()
    {
        gemsText.text = ("X " + gems);
        coinsText.text = ("X " + coins);
        ancientText.text = ("X " + ancients);

    }

    public void Next(){
        if (GameMaster.humans>0)
        {
            
            SceneManager.LoadScene(3);
            PlayerController.gameOver = false;
            PlayerController.gameFinish = false;
            SpawnRooms.stopSpawnRoom = false;
            PauseMenu.paused = false;
            PauseMenu.restartTrigger = true;
            
            
        }else{
            GameOverPanel.SetActive(true);
        }
        
    }

    public void Submit()
    {
        gm.coins -= coins;
        gm.gems -= gems;
        gm.ancients -= ancients;

        PlayerController.nextCoin -=coins;
        PlayerController.nextGem -= gems;
        PlayerController.nextAncient -= ancients;

        countGods[DialogManager.GodName]++;

        score_need += coins*20;
        score_need += gems*100;
        score_need += ancients*200;

        if (score_need >= (countGods[DialogManager.GodName]* 200 - 20) && score_need <= (countGods[DialogManager.GodName]* 200 + 20))
        {
            // Debug.Log("Gods satisfied ");
            PlayerController.nextScore += countGods[DialogManager.GodName] * 1000;
            GodsMassage  = 1;
        } else if (score_need < (countGods[DialogManager.GodName]* 200 - 20))
        {
            // Debug.Log("Gods sad ");
            GameMaster.humans  -= countGods[DialogManager.GodName];
            GodsMassage = 2;
        } else  
        {
            // Debug.Log("Gods happy");
            GodsMassage = 3;
            PlayerController.nextScore += countGods[DialogManager.GodName] * 1200;
            countGods[DialogManager.GodName] -- ;
        }


        MassagePanel.SetActive(true);
        gm.SavePlayer();

        
        if (GodsMassage == 1)
        {
            Massage.text = "GODS SATISFIED!";
        }
        else if (GodsMassage == 2)
        {
            Massage.text = "GODS SAD!";
        }
        else
        {
            Massage.text = "GODS HAPPY!";
        }
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        PauseMenu.restartTrigger = true;
    }
    public void PlusCoinButton()
    {
        if(gm.coins >= coins+2)
            coins +=2;
    }
    public void MinusCoinButton()
    {
        if(coins>= 2)
        coins -=2;
    }
    public void PlusGemButton()
    {
        if(gm.gems >= gems+1)
        gems ++;
    }
    public void MinusGemButton()
    {
        if(gems>= 1)
        gems --;
    }
    public void PlusAncientsButton()
    {
        if(gm.ancients >= ancients+1)
        ancients ++;
    }
    public void MinusAncientsButton()
    {
        if(ancients>=1)
        ancients --;
    }
}
