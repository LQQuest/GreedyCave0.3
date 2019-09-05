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

    void Start()
    {
        highScore.text = ("High Score: " + PlayerPrefs.GetInt("HighScore",0).ToString());
        dayScore.text = ("Maximum days: " + PlayerPrefs.GetInt("DayScore",0).ToString());

        tutorMenu.SetActive(false);
    }
    public void StartGameFirst()
    {
        SceneManager.LoadScene(1);
        PlayerController.gameOver = false;
        PlayerController.gameFinish = false;
        SpawnRooms.stopSpawnRoom = false;
        PauseMenu.paused = false;
        PlayerController.hp = 6;
        GameMaster.humans = 10;
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
