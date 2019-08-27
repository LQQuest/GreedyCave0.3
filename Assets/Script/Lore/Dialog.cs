using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{   
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float  typingSpeed;
    public GameObject countinueButton;

    void Start(){
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
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }else
        {
            textDisplay.text = "";
            countinueButton.SetActive(false);
        }
    }
}
