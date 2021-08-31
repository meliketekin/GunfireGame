using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class gameOptionsManager : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOptionsPanel;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip buttonClick;
    void Start()
    {
        gameOptionsPanel.GetComponent<CanvasGroup>().DOFade(1, 1f);
        gameOptionsPanel.GetComponent<RectTransform>().DOScale(1, 1f).SetEase(Ease.OutBack);
    }

   public void goBackButton()
    {
        if (PlayerPrefs.GetInt("soundControl") == 1)
        {
            audioSource.PlayOneShot(buttonClick);
        }
        SceneManager.LoadScene("MenuScene");
    }
    public void WhichGame(string gameOption)
    {
        if (PlayerPrefs.GetInt("soundControl") == 1)
        {
            audioSource.PlayOneShot(buttonClick);
        }
        PlayerPrefs.SetString("whichGame", gameOption);
        SceneManager.LoadScene("GameScene");
    }
}
