using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tavern : MonoBehaviour
{
    public TextMeshProUGUI level_1_text;
    public TextMeshProUGUI level_2_text;
    public TextMeshProUGUI costAncientText;
    // public TextMeshProUGUI costCoinText;
    public TextMeshProUGUI valueText;
    public TextMeshProUGUI lootText;

    private int costCoin;
    private int costAncient;

    public GameObject panel;
    private GameMaster gm;
    public GameObject lvlUpPanel;
    public GameObject lvlMaxPanel;


    

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
        lootText.text = ("+" + (GameMaster.tavern-1));
        if (GameMaster.villageLoot == true)
        {
            gm.food += GameMaster.tavern;
            PlayerController.nextFood += GameMaster.tavern - 1; 
        }
        
        gameObject.SetActive(false);
        if (GameMaster.tavern == 4)
        {
            lvlMaxPanel.SetActive(true);
        }
        
    }

    void Update()
    {
        level_1_text.text = ("Level " + GameMaster.tavern);
        level_2_text.text = ("Level " + GameMaster.tavern + "->" + (GameMaster.tavern+1));
        
        valueText.text = ("+" + (GameMaster.tavern));

        if (GameMaster.tavern == 1)
        {
            costAncient = 1;
            
            costAncientText.text = ("- " + costAncient);
            
        } else if (GameMaster.tavern == 2)
        {
            costAncient = 4;
            
            costAncientText.text = ("- " + costAncient);
            
        } else if (GameMaster.tavern == 3)
        {
            costAncient = 10;
            
            costAncientText.text = ("- " + costAncient );
            
        }
    }
    public void newPanel()
    {
        panel.SetActive(true);
    }

    public void Confirm()
    {
        if ( gm.ancients >= costAncient)
        {   
            
            gm.ancients -= costAncient;    
            
            PlayerController.nextAncient -= costAncient;
            panel.SetActive(false);
            GameMaster.tavern ++;
            if (GameMaster.tavern == 4)
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
