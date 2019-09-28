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
    public GameObject lvlUpPanel;
    public GameObject lvlMaxPanel;


   

    void Start()
    {
        // lvlMaxPanel.SetActive(false);
        // lvlUpPanel.SetActive(false);
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
        lootText.text = ("+" + (GameMaster.levelGemHouse-1));
        if(GameMaster.villageLoot == true)
        {
           gm.gems += GameMaster.levelGemHouse-1; 
           PlayerController.nextGem += (GameMaster.levelGemHouse-1);
        }
        
        
        gameObject.SetActive(false);
        if (GameMaster.levelGemHouse == 1)
        {
            cost = GameMaster.costGemHouse;
        }else if(GameMaster.levelGemHouse == 2)
        {
            cost = GameMaster.costGemHouse+2;
            GameMaster.costGemHouse += 2;
        }else{
            cost = GameMaster.costGemHouse + 2*GameMaster.levelGemHouse;
            GameMaster.costGemHouse += 2*GameMaster.levelGemHouse;
        }
        if (GameMaster.levelGemHouse == 8)
        {
            lvlMaxPanel.SetActive(true);
        }
        costText.text = ("- " + cost );
        valueText.text = ("+" + (GameMaster.levelGemHouse));
    }

    void Update()
    {
        

        level_1_text.text = ("Level " + GameMaster.levelGemHouse);
        level_2_text.text = ("Level " + GameMaster.levelGemHouse + "->" + (GameMaster.levelGemHouse+1));
        
        

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
            if (GameMaster.levelGemHouse == 8)
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
