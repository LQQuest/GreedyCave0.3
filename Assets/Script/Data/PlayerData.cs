using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int hp;
    public int day;
    public int score;
    public int gems;
    public int coins;
    public int ancients;
    public int humans;
    public int food;
    public int scene;
    public int levelAncientHouse;
    public int levelGemHouse;
    public int levelCoinHouse;
    public int tavern;

    public PlayerData (GameMaster gm)
    {
        
        score = gm.score;
        gems = gm.gems;
        coins = gm.coins;
        ancients = gm.ancients;
        food = gm.food;
        humans = GameMaster.humans;
        day = GameMaster.day;
        scene = GameMaster.scene;
        levelAncientHouse = GameMaster.levelAncientHouse;
        levelCoinHouse = GameMaster.levelCoinHouse;
        levelGemHouse = GameMaster.levelGemHouse;
        tavern = GameMaster.tavern;
    }
}
