using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Castel : MonoBehaviour
{
    
    public TextMeshProUGUI costGemText;
    public TextMeshProUGUI costCoinText;
    public TextMeshProUGUI valueText;

    private int costCoin = 50;
    private int costGem = 10;

    private GameMaster gm;


    

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();

        
    }

    void Update()
    {
        
        costGemText.text = ("- " + costGem );
        costCoinText.text = ("- " + costCoin );
        valueText.text = ("+" + GameMaster.levelAncientHouse);
    }
    

    public void Confirm()
    {
        if (gm.coins >= costCoin && gm.gems >= costGem)
        {   
            gm.coins -= costCoin;
            gm.gems -= costGem;    
            PlayerController.nextCoin -= costCoin;
            PlayerController.nextGem -= costGem;
            
            GameMaster.humans ++;
        }
    }
    
}
