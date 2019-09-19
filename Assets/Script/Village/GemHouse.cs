using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GemHouse : MonoBehaviour
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
        lootText.text = ("+" + GameMaster.levelGemHouse);
        gm.gems += GameMaster.levelGemHouse;
        PlayerController.nextGem += GameMaster.levelGemHouse;
        gameObject.SetActive(false);
    }

    void Update()
    {
        cost = GameMaster.levelGemHouse * 7 + (GameMaster.levelGemHouse-1)*2;

        level_1_text.text = ("Level " + GameMaster.levelGemHouse);
        level_2_text.text = ("Level " + GameMaster.levelGemHouse + "->" + (GameMaster.levelGemHouse+1));
        costText.text = ("- " + cost );
        valueText.text = ("+" + GameMaster.levelGemHouse);
    }
    public void newPanel()
    {
        panel.SetActive(true);
    }

    public void Confirm()
    {
        if (gm.coins >= cost)
        {   
            gm.coins -= cost;   
            PlayerController.nextCoin -= cost; 
            panel.SetActive(false);
            GameMaster.levelGemHouse ++;
        }
    }
    public void Back()
    {
        panel.SetActive(false);
    }
}
