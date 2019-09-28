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
    public int levelFoodHouse;
    public int levelGemHouse;
    public int levelCoinHouse;
    public int tavern;
    public int weed;
    public int costGemHouse;
    public int costCoinHouse;
    public bool villageLoot;

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
        levelFoodHouse = GameMaster.levelFoodHouse;
        levelCoinHouse = GameMaster.levelCoinHouse;
        levelGemHouse = GameMaster.levelGemHouse;
        tavern = GameMaster.tavern;
        weed = GameMaster.weed;
        costGemHouse = GameMaster.costGemHouse;
        costCoinHouse = GameMaster.costCoinHouse;
        hp = GameMaster.hp;
        villageLoot = GameMaster.villageLoot;
    }
}
