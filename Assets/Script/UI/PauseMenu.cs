using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseUI;
    public GameObject GameOverUI;
    public GameObject LoadScreen;
    public GameObject FinishUI;
    private GameMaster gm;


    public static bool paused = false;
    public static bool restartTrigger = false;
    

    void Start()
    {
        PauseUI.SetActive(false); 
        GameOverUI.SetActive(false); 
        LoadScreen.SetActive(true);
        FinishUI.SetActive(false);
        restartTrigger = false;
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();


    }

    void Update()
    {
        if(Input.GetButtonDown("Pause")){
            paused = !paused;
        }
        if (paused){
            PauseUI.SetActive(true);
            Time.timeScale = 0;
        }
        if(!paused){
            PauseUI.SetActive(false);
            Time.timeScale = 1;
        }
        StartCoroutine(GameOverMenu());
    }

    public void PauseGame()
    {
        paused = true;
    }

    public void Resume ()
    {
        paused = false;
    }
    public void Next()
    {
        if ((GameMaster.day + 1) % 2 == 0)
        {
            SceneManager.LoadScene(2);
        }else{
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
        PlayerController.gameOver = false;
        PlayerController.gameFinish = false;
        SpawnRooms.stopSpawnRoom = false;
        paused = false;
        restartTrigger = true;
        GameMaster.day ++;
        
    }
    public void Restart()
    {
        if (PlayerController.gameOver == true)
        {
            GameMaster.humans --;
        }
        PlayerController.gameOver = false;
        PlayerController.gameFinish = false;
        SpawnRooms.stopSpawnRoom = false;
        PlayerController.hp = 6;
        paused = false;
        restartTrigger = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        restartTrigger = true;
    }
    public void Quit()
    {
        Application.Quit();
    }


    private IEnumerator GameOverMenu()
    {
        if (PlayerController.gameOver)
        {
            yield return new WaitForSeconds(2f);
            GameOverUI.SetActive(true);
        
        }
        
    }
}
