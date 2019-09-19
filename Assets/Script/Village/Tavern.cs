using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tavern : MonoBehaviour
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


    

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
        lootText.text = ("+" + GameMaster.tavern);
        gm.food += GameMaster.tavern;
        PlayerController.nextFood += GameMaster.tavern;
        gameObject.SetActive(false);
        
    }

    void Update()
    {
        costCoin = GameMaster.tavern * 7 + (GameMaster.tavern-1)*2;
        costGem = GameMaster.tavern + (GameMaster.tavern - 1);
        level_1_text.text = ("Level " + GameMaster.tavern);
        level_2_text.text = ("Level " + GameMaster.tavern + "->" + (GameMaster.tavern+1));
        costGemText.text = ("- " + costGem );
        costCoinText.text = ("- " + costCoin );
        valueText.text = ("+" + GameMaster.tavern);
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
            GameMaster.tavern ++;
        }
    }
    public void Back()
    {
        panel.SetActive(false);
    }
}
