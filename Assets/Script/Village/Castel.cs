using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Castel : MonoBehaviour
{
    
    public TextMeshProUGUI costAncientText;
    public TextMeshProUGUI costWeedText;
    public TextMeshProUGUI valueText;

    private int costWeed = 30;
    private int costAncient = 2;

    private GameMaster gm;


    

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();

        
    }

    void Update()
    {
        
        costAncientText.text = ("- " + costAncient );
        costWeedText.text = ("- " + costWeed );
        valueText.text = ("+1"  );
    }
    

    public void Confirm()
    {
        if (GameMaster.weed >= costWeed && gm.ancients >= costAncient)
        {   
            GameMaster.weed -= costWeed;
            gm.ancients -= costAncient;    
            PlayerController.nextAncient -= costAncient;
            
            GameMaster.humans ++;
        }
    }
    
}
