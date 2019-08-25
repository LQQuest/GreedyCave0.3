using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    public int score;
    public int gems;
    public int coins;
    public int heals;
    public Text pointsText;
    public Text gemsText;
    public Text coinsText;
    public Text foodText;

    void Start()
    {
        score = PlayerController.nextscore;
        gems = PlayerController.nextgem;
        coins = PlayerController.nextcoin;
        heals = PlayerController.nextfood;

    }

    void Update()
    {
        
        pointsText.text = ("Score: " + score);
        gemsText.text = ("X " + gems);
        coinsText.text = ("X " + coins);
        foodText.text = ("X " + heals);

        if (Input.GetKeyDown(KeyCode.C) && PlayerController.hp < 6 && heals > 0)
        {
            heals--;
            PlayerController.hp++;
        }

        
        if (score > PlayerPrefs.GetInt("HighScore",0))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
}
