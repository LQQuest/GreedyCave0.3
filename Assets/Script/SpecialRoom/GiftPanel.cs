using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GiftPanel : MonoBehaviour
{

    public Text ancientText;
    public Text gemsText;
    public Text coinsText;

    public int gems;
    public int coins;
    public int ancients;


    void Start()
    {
        
    }

    void Update()
    {
        gemsText.text = ("X " + gems);
        coinsText.text = ("X " + coins);
        ancientText.text = ("X " + ancients);

    }

    public void PlusButton()
    {
        
    }
}
