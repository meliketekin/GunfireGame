using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject startImage, trueIcon, falseIcon;
    [SerializeField]
    private Text questionText, leftText, middleText, rightText, trueCountertxt, falseCountertxt, scoretxt;
    [SerializeField]
    private AudioClip startSound;
    [SerializeField]
    private AudioSource audioSource;
    string whichGame;
    int firstMultiplier,secondMultiplier;
    public int totalScore, trueCounter, falseCounter;
    private int scoreInc, trueAnswer;
    timeManager timeManager;
    playerManager playerManager;
    void Start()
    {
        trueIcon.GetComponent<RectTransform>().localScale = Vector3.zero;
        falseIcon.GetComponent<RectTransform>().localScale = Vector3.zero;
        timeManager = Object.FindObjectOfType<timeManager>();
        playerManager = Object.FindObjectOfType<playerManager>();
        trueCounter = 0;
        falseCounter = 0;
        totalScore = 0;

        StartCoroutine(startImageRoutine());
        if(PlayerPrefs.HasKey("whichGame"))
        {
            whichGame = PlayerPrefs.GetString("whichGame");
            Debug.Log(whichGame);
        }
       
    }

    IEnumerator startImageRoutine()
    {
        startImage.GetComponent<RectTransform>().DOScale(1.3f, 1f);
        yield return new WaitForSeconds(1.1f);
        startImage.GetComponent<RectTransform>().DOScale(0, 0.5f).SetEase(Ease.InBack);
        startImage.GetComponent<CanvasGroup>().DOFade(0, 1f);
        yield return new WaitForSeconds(0.6f);
        startGame();
        
    }
    public void startGame()
    {
        if (PlayerPrefs.GetInt("soundControl") == 1)
        {
            audioSource.PlayOneShot(startSound);
        }
        timeManager.StartCoroutine("countTime");
        playerManager.isRotate = true;
        setFirstMultiplier();
        printQuestion();
        
    }
    void setFirstMultiplier()
    {
        switch(whichGame)
        {
            case "two":
                firstMultiplier = 2;
                scoreInc += 20;
                break;
            case "three":
                firstMultiplier = 3;
                scoreInc += 25;
                break;
            case "four":
                firstMultiplier = 4;
                scoreInc += 30;
                break;
            case "five":
                firstMultiplier = 5;
                scoreInc += 35;
                break;
            case "six":
                firstMultiplier = 6;
                scoreInc += 40;
                break;
            case "seven":
                firstMultiplier = 7;
                scoreInc += 45;
                break;
            case "eight":
                firstMultiplier = 8;
                scoreInc += 50;
                break;
            case "nine":
                firstMultiplier = 9;
                scoreInc += 55;
                break;
            case "ten":
                firstMultiplier = 10;
                scoreInc += 60;
                break;
            case "mix":
                firstMultiplier = Random.Range(2,11);
                scoreInc += 65;
                break;

                
        }
Debug.Log(firstMultiplier);
        
    }
    public void printQuestion()
    {
        secondMultiplier = Random.Range(2, 15);
        int value = Random.Range(1, 100);
        if(value<=50)
        {
            questionText.text = firstMultiplier.ToString() + " x " + secondMultiplier.ToString();
        }
        else
        {
            questionText.text = secondMultiplier.ToString() + " x " + firstMultiplier.ToString();
        }
        printAnswer();
    }
    void printAnswer()
    {
        trueAnswer = firstMultiplier * secondMultiplier;
        int randomValue = Random.Range(1, 60);
        if(randomValue<=20)
        {
            leftText.text = trueAnswer.ToString();
            middleText.text = (trueAnswer - Random.Range(1, 10)).ToString();
            rightText.text = (trueAnswer + Random.Range(1, 10)).ToString();

        }
        else if (randomValue <= 20)
        {
            middleText.text = trueAnswer.ToString();
            leftText.text = (trueAnswer + Random.Range(1, 10)).ToString();
            rightText.text = (trueAnswer - Random.Range(1, 10)).ToString();
        }
        else
        {
            rightText.text = trueAnswer.ToString();
            middleText.text = (trueAnswer + Random.Range(1, 10)).ToString();
            leftText.text = (trueAnswer - Random.Range(1, 10)).ToString();
        }
    }
    public void checkResult(int value)
    {
        if(value==trueAnswer)
        {
            
            StartCoroutine(iconAppearance(true));
            trueCounter++;
            totalScore += scoreInc;
            Debug.Log("true");
            
        }
        else
        {
            StartCoroutine(iconAppearance(false));
            
            falseCounter++;
            Debug.Log("false");
        }
        trueCountertxt.text = trueCounter.ToString() + " TRUE";
        falseCountertxt.text = falseCounter.ToString() + " FALSE";
        scoretxt.text = totalScore.ToString() + " SCORE";
    }
    IEnumerator iconAppearance(bool isTrue)
    {
        if(isTrue)
        {
            trueIcon.GetComponent<RectTransform>().DOScale(1, 0.2f);
            yield return new WaitForSeconds(0.5f);
            trueIcon.GetComponent<RectTransform>().DOScale(0, 0.2f);
        }
        else if(!isTrue)
        {
            falseIcon.GetComponent<RectTransform>().DOScale(1, 0.2f);
            yield return new WaitForSeconds(0.5f);
            falseIcon.GetComponent<RectTransform>().DOScale(0, 0.2f);
        }
    }
    
}
