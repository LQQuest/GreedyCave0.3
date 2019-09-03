using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogManager : MonoBehaviour
{   
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float  typingSpeed;
    public GameObject countinueButton;
    private int randGod;
    

    void Start(){
        index = Random.Range(0,3);
        StartCoroutine(Type());

        
    }
    void Update(){
        if(textDisplay.text == sentences[index]){
            countinueButton.SetActive(true);
        }
    }

    IEnumerator Type(){
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text +=letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
    public void NextSentence(){

        countinueButton.SetActive(false);
        if (index < sentences.Length -1)
        {
            index = 3;
            textDisplay.text = "";
            StartCoroutine(Type());
        }else
        {
            textDisplay.text = "";
            countinueButton.SetActive(false);
        }
    }
}
