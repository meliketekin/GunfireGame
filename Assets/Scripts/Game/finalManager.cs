using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class finalManager : MonoBehaviour
{
    [SerializeField]
    private Image finalImage;
    [SerializeField]
    private Text trueTxt, falseTxt, scoreTxt;
    [SerializeField]
    private GameObject backMenuBtn, playAgainBtn;
    GameManager gameManager;
    float timer;
    bool isOpen;
    private void OnEnable()
    {
        timer = 0;
        isOpen = true;
       
        trueTxt.text = "";
        falseTxt.text = "";
        scoreTxt.text = "";
        backMenuBtn.GetComponent<RectTransform>().localScale = Vector3.zero;
        playAgainBtn.GetComponent<RectTransform>().localScale = Vector3.zero;
        gameManager = Object.FindObjectOfType<GameManager>();
        StartCoroutine(ImageOpen());
    }
    
    IEnumerator ImageOpen()
    {
        while(isOpen)
        {
            timer += .15f;
            finalImage.fillAmount = timer;
            yield return new WaitForSeconds(0.1f);

            if(timer>=1) {
                timer = 1;
                isOpen = false;
                trueTxt.text = gameManager.trueCounter.ToString() + " TRUE";
                falseTxt.text = gameManager.falseCounter.ToString() + " FALSE";
                scoreTxt.text = gameManager.totalScore.ToString()+ " SCORE";
                backMenuBtn.GetComponent<RectTransform>().DOScale(1,0.3f);
                playAgainBtn.GetComponent<RectTransform>().DOScale(1,0.3f);
            }

        }
    }
    public void backtoMenu()
    {
        SceneManager.LoadScene("GameOptionsScene");
    }
    public void playAgain()
    {
        SceneManager.LoadScene("GameScene");
    }
}
