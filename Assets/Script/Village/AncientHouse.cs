using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AncientHouse : MonoBehaviour
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
        lootText.text = ("+" + GameMaster.levelAncientHouse);
        gm.ancients += GameMaster.levelAncientHouse;
        PlayerController.nextAncient += GameMaster.levelAncientHouse;
        gameObject.SetActive(false);
        
    }

    void Update()
    {
        costCoin = GameMaster.levelAncientHouse * 7 + (GameMaster.levelAncientHouse-1)*2;
        costGem = GameMaster.levelAncientHouse + (GameMaster.levelAncientHouse - 1);
        level_1_text.text = ("Level " + GameMaster.levelAncientHouse);
        level_2_text.text = ("Level " + GameMaster.levelAncientHouse + "->" + (GameMaster.levelAncientHouse+1));
        costGemText.text = ("- " + costGem );
        costCoinText.text = ("- " + costCoin );
        valueText.text = ("+" + GameMaster.levelAncientHouse);
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
            GameMaster.levelAncientHouse ++;
        }
    }
    public void Back()
    {
        panel.SetActive(false);
    }
}
