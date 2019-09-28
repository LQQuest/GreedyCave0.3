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
        
        PlayerController.gameOver = false;
        PlayerController.gameFinish = false;
        SpawnRooms.stopSpawnRoom = false;
        PauseMenu.paused = false;
        GameMaster.hp = 6;
        GameMaster.humans = 10;
        GameMaster.day = 1;
        GameMaster.weed = 0;
        GameMaster.costGemHouse = 10;
        GameMaster.costCoinHouse = 2;
        GameMaster.levelFoodHouse = 1;
        GameMaster.levelCoinHouse = 1;
        GameMaster.levelGemHouse = 1;
        GameMaster.tavern = 1;

        PlayerController.nextScore = 0;
        PlayerController.nextGem = 0;
        PlayerController.nextCoin = 0;
        PlayerController.nextFood = 0;
        PlayerController.nextAncient = 0;

        // gm.SavePlayer();
        SceneManager.LoadScene(1);
    }
    public void LoadGame()
    {
        gm.LoadPlayer();
        PlayerController.gameOver = false;
        PlayerController.gameFinish = false;
        SpawnRooms.stopSpawnRoom = false;
        PauseMenu.paused = false;
        SceneManager.LoadScene(GameMaster.scene);
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
