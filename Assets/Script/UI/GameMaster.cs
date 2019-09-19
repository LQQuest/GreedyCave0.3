using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameMaster : MonoBehaviour
{
    public int score;
    public int gems;
    public int coins;
    public int ancients;
    public static int humans;
    public int food;
    
    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI gemsText;
    public TextMeshProUGUI coinsText;
    public TextMeshProUGUI ancientsText;
    public TextMeshProUGUI humanText;
    public TextMeshProUGUI dayText;
    public TextMeshProUGUI foodText;
    public static int day = 1;
    public static int hp = 6;
    public static int scene;
    public static int levelAncientHouse = 1;
    public static int levelGemHouse = 1;
    public static int levelCoinHouse = 1;
    public static int tavern = 1;

    void Start()
    {
        score = PlayerController.nextScore;
        gems = PlayerController.nextGem;
        coins = PlayerController.nextCoin;
        food = PlayerController.nextFood;
        ancients = PlayerController.nextAncient;


    }

    void Update()
    {
        
        pointsText.text = ("Score: " + score);
        gemsText.text = ("X " + gems);
        coinsText.text = ("X " + coins);
        ancientsText.text = ("X " + ancients);
        humanText.text = ("X " + humans);
        dayText.text = ("Day " + day);
        foodText.text = ("X " + food);

        if (Input.GetKeyDown(KeyCode.C) && hp < 6 && food > 0)
        {
            food--;
            hp++;
        }

        
        if (score > PlayerPrefs.GetInt("HighScore",0))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
        if (day > PlayerPrefs.GetInt("DayScore",0))
        {
            PlayerPrefs.SetInt("DayScore", day);
        }
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        score = data.score;
        gems = data.gems;
        coins = data.coins;
        ancients = data.ancients;
        food = data.food;
        humans = data.humans;
        hp = data.hp;
        day = data.day;
        scene = data.scene;
        levelGemHouse = data.levelGemHouse;
        levelCoinHouse = data.levelCoinHouse;
        levelAncientHouse = data.levelAncientHouse;
        tavern = data.tavern;
    }
}
