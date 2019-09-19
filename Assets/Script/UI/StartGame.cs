using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class StartGame : MonoBehaviour
{
    public TextMeshProUGUI highScore;
    public TextMeshProUGUI dayScore;
    public GameObject tutorMenu;

    private GameMaster gm;

    void Start()
    {
        highScore.text = ("High Score: " + PlayerPrefs.GetInt("HighScore",0).ToString());
        dayScore.text = ("Maximum days: " + PlayerPrefs.GetInt("DayScore",0).ToString());
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();

        tutorMenu.SetActive(false);
    }
    public void StartGameFirst()
    {
        SceneManager.LoadScene(1);
        PlayerController.gameOver = false;
        PlayerController.gameFinish = false;
        SpawnRooms.stopSpawnRoom = false;
        PauseMenu.paused = false;
        GameMaster.hp = 6;
        GameMaster.humans = 10;
        GameMaster.day = 1;

        PlayerController.nextScore = 0;
        PlayerController.nextGem = 0;
        PlayerController.nextCoin = 0;
        PlayerController.nextFood = 0;
        PlayerController.nextAncient = 0;

        gm.SavePlayer();
        
    }
    public void LoadGame()
    {
        SceneManager.LoadScene(1);
        PlayerController.gameOver = false;
        PlayerController.gameFinish = false;
        SpawnRooms.stopSpawnRoom = false;
        PauseMenu.paused = false;
        gm.LoadPlayer();
    }

    public void TutorMenu()
    {
        tutorMenu.SetActive(true);
    }
    public void TutorMenuQuit()
    {
        tutorMenu.SetActive(false);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
