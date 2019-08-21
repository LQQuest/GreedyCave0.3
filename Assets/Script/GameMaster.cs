using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    public int score;
    public Text pointsText;

    void Start()
    {
        score = PlayerController.nextscore;
    }

    void Update()
    {
        
        pointsText.text = ("Score: "+ score);

        if (score > PlayerPrefs.GetInt("HighScore",0))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
}
