using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FoodHouse : MonoBehaviour
{
    public TextMeshProUGUI level_1_text;
    public TextMeshProUGUI level_2_text;
    public TextMeshProUGUI costGemText;
    public TextMeshProUGUI costCoinText;
    public TextMeshProUGUI valueText;
    public TextMeshProUGUI lootText;

    private int costCoin;
    private int costGem;

    public GameObject panel;
    private GameMaster gm;
    public GameObject lvlUpPanel;
    public GameObject lvlMaxPanel;


    

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
        lootText.text = ("+" + ((GameMaster.levelFoodHouse-1)*10));
        if (GameMaster.villageLoot == true)
        {
           GameMaster.weed += (GameMaster.levelFoodHouse -1)*10;
        }
        
        gameObject.SetActive(false);
        if (GameMaster.levelFoodHouse == 4)
        {
            lvlMaxPanel.SetActive(true);
        }
    }

    void Update()
    {
        
        level_1_text.text = ("Level " + GameMaster.levelFoodHouse);
        level_2_text.text = ("Level " + GameMaster.levelFoodHouse + "->" + (GameMaster.levelFoodHouse+1));
        if (GameMaster.levelFoodHouse == 1)
        {
            costGem = 3;
            costCoin = 30;
            costGemText.text = ("- " + costGem);
            costCoinText.text = ("- " + costCoin);
        } else if (GameMaster.levelFoodHouse == 2)
        {
            costGem = 7;
            costCoin = 56;
            costGemText.text = ("- " + costGem);
            costCoinText.text = ("- " + costCoin);
        } else if (GameMaster.levelFoodHouse == 3)
        {
            costGem = 16;
            costCoin = 110;
            costGemText.text = ("- " + costGem );
            costCoinText.text = ("- " + costCoin );
        }
        
        valueText.text = ("+" + (GameMaster.levelFoodHouse)*10);
    }
    public void newPanel()
    {
        panel.SetActive(true);
    }

    public void Confirm()
    {
        if (gm.coins >= costCoin && gm.gems >= costGem)
        {   
            gm.coins -= costCoin;
            gm.gems -= costGem;    
            PlayerController.nextCoin -= costCoin;
            PlayerController.nextGem -= costGem;
            panel.SetActive(false);
            GameMaster.levelFoodHouse ++;
            if (GameMaster.levelFoodHouse == 4)
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
