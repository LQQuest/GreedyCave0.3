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




    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
        lootText.text = ("+" + GameMaster.levelCoinHouse*4);
        gm.coins += GameMaster.levelCoinHouse*4;
        PlayerController.nextCoin += GameMaster.levelCoinHouse*4;
        gameObject.SetActive(false);
    }

    void Update()
    {
        cost = GameMaster.levelCoinHouse  + (GameMaster.levelCoinHouse-1);
        level_1_text.text = ("Level " + GameMaster.levelCoinHouse);
        level_2_text.text = ("Level " + GameMaster.levelCoinHouse + "->" + (GameMaster.levelCoinHouse+1));
        costText.text = ("- " + cost );
        valueText.text = ("+" + (GameMaster.levelCoinHouse*4));
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
        }
    }
    public void Back()
    {
        panel.SetActive(false);
    }
}
