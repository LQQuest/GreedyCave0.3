using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public Text highScore;
    public GameObject tutorMenu;

    void Start()
    {
        highScore.text = ("High Score: " + PlayerPrefs.GetInt("HighScore",0).ToString());
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
