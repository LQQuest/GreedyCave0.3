using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinHouse : MonoBehaviour
{
    public TextMeshProUGUI level_1_text;
    public TextMeshProUGUI level_2_text;
    public TextMeshProUGUI costText;
    public TextMeshProUGUI valueText;
    public TextMeshProUGUI lootText;

    private int cost;

    public GameObject panel;
    private GameMaster gm;
    public GameObject lvlUpPanel;
    public GameObject lvlMaxPanel;




    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
        
        
        if(GameMaster.levelCoinHouse == 7)
        {
            if (GameMaster.villageLoot == true)
            {
                
                gm.coins += 13;
                PlayerController.nextCoin += 13;
            }
            
            lootText.text = ("+13");
            valueText.text = ("+17");
        }else if (GameMaster.levelCoinHouse == 8)
        {

            if (GameMaster.villageLoot == true)
            {
               
                gm.coins += 17;
                PlayerController.nextCoin += 17;
            }
        
            lootText.text = ("+17");
            valueText.text = ("");
        }else{

            if (GameMaster.villageLoot == true)
            {
                
                gm.coins += (GameMaster.levelCoinHouse - 1)*2;
                PlayerController.nextCoin += (GameMaster.levelCoinHouse - 1)*2;
            }
            
            lootText.text = ("+" + (GameMaster.levelCoinHouse - 1)*2);
            valueText.text = ("+" + (GameMaster.levelCoinHouse)*2);
        }

        if (GameMaster.levelCoinHouse == 8)
        {
            lvlMaxPanel.SetActive(true);
        }
        if (GameMaster.levelCoinHouse == 1)
        {
            cost = GameMaster.costCoinHouse;
            costText.text = ("- " + cost);
            
        }else if (GameMaster.levelCoinHouse == 2)
        {
            cost = 2*GameMaster.costCoinHouse;
            GameMaster.costCoinHouse *=2;
            costText.text = ("- " + cost);
            
        }else{
            cost = GameMaster.costCoinHouse + GameMaster.levelCoinHouse;
            GameMaster.costCoinHouse += cost;
            costText.text = ("- " + cost);
        }
        
        
        gameObject.SetActive(false);
    }

    void Update()
    {
        
        level_1_text.text = ("Level " + GameMaster.levelCoinHouse);
        level_2_text.text = ("Level " + GameMaster.levelCoinHouse + "->" + (GameMaster.levelCoinHouse+1));
        
        

        

    }
    public void newPanel()
    {
        panel.SetActive(true);
    }

    public void Confirm()
    {
        if (gm.gems >= cost)
        {   
            gm.gems -= cost;    
            PlayerController.nextGem -= cost;
            panel.SetActive(false);
            GameMaster.levelCoinHouse ++;
            if (GameMaster.levelCoinHouse == 8)
            {
                lvlMaxPanel.SetActive(true);
            }else{
                lvlUpPanel.SetActive(true);
            }
        }
    }
    public void Back()
    {
        panel.SetActive(false);
    }
}
