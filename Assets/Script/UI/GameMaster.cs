using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    public int score;
    public int gems;
    public int coins;
    public int food;
    public int ancients;
    public int humans;
    public Text pointsText;
    public Text gemsText;
    public Text coinsText;
    public Text foodText;
    public Text dayText;
    public Text ancientText;
    public Text humanText;
    public static int day = 1;

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
        foodText.text = ("X " + food);
        dayText.text = ("Day " + day);
        ancientText.text = ("X " + ancients);
        humanText.text = ("X " + humans);

        if (Input.GetKeyDown(KeyCode.C) && PlayerController.hp < 6 && food > 0)
        {
            food--;
            PlayerController.hp++;
        }

        
        if (score > PlayerPrefs.GetInt("HighScore",0))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
}
