using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHeatr : MonoBehaviour
{
    public int health;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite halfHeart;
    public Sprite rawHeart;

    void Update()
    {
        health = GameMaster.hp;

        for (int i = 0; i < hearts.Length; i++)
        {
            if ((i+1)*2<=health){
                hearts[i].sprite = fullHeart;
            } else if(((i+1)*2)-1<=health){
                hearts[i].sprite = halfHeart;
            } else{
                hearts[i].sprite = rawHeart;
            }

        }
    }
}
