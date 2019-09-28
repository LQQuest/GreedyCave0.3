using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Village : MonoBehaviour
{

    public GameObject gemButton;
    public GameObject coinButton;
    public GameObject foodButton;
    public GameObject ancientButton;
    public GameObject humanButton;
    public GameObject graveyardButton;
    public GameObject LoadScreen;

    public GameObject CanvasUI;
    private GameMaster gm;
    public GameObject message;


    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
        message.SetActive(true);
        GameMaster.scene = 3;
        
    }

    void Update()
    {
        LoadScreen.SetActive(false);
    }

    public void MainMenu()
    {
        
        GameMaster.villageLoot = false;
        SceneManager.LoadScene(0);
        PauseMenu.restartTrigger = true;
        gm.SavePlayer();
    }

    public void PauseGame()
    {
        PauseMenu.paused = !PauseMenu.paused;
        CanvasUI.GetComponent<CanvasGroup>().blocksRaycasts = !CanvasUI.GetComponent<CanvasGroup>().blocksRaycasts;
    }
    public void Close()
    {
        message.SetActive(false);
    }
    
    public void NextDay()
    {
        gm.SavePlayer();
        GameMaster.day ++;
        SceneManager.LoadScene(1);
        GameMaster.villageLoot = true;
    }

    public void GemButton()
    {
        OffButton();
        gemButton.transform.GetChild(0).gameObject.SetActive(true);
    }
    public void CoinButton()
    {
        OffButton();
        coinButton.transform.GetChild(0).gameObject.SetActive(true);
    }
    public void AncientButton()
    {
        OffButton();
        ancientButton.transform.GetChild(0).gameObject.SetActive(true);
    }
    public void FoodButton()
    {
        OffButton();
        foodButton.transform.GetChild(0).gameObject.SetActive(true);
    }
    public void HumanButton()
    {
        OffButton();
        humanButton.transform.GetChild(0).gameObject.SetActive(true);
    }
    public void GraveyardButton()
    {
        OffButton();
        graveyardButton.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void OffButton()
    {
        gemButton.transform.GetChild(0).gameObject.SetActive(false);
        coinButton.transform.GetChild(0).gameObject.SetActive(false);
        foodButton.transform.GetChild(0).gameObject.SetActive(false);
        ancientButton.transform.GetChild(0).gameObject.SetActive(false);
        humanButton.transform.GetChild(0).gameObject.SetActive(false);
        graveyardButton.transform.GetChild(0).gameObject.SetActive(false);

    }
}
