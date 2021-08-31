using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject menuPanel, soundControl;
    [SerializeField]
    private AudioClip buttonClick;
    [SerializeField]
    private AudioSource audioSource;
    void Start()
    {
        soundControl.GetComponent<RectTransform>().localPosition =new Vector3(5,-39);
        menuPanel.GetComponent<CanvasGroup>().DOFade(1, 1f);
        menuPanel.GetComponent<RectTransform>().DOScale(1, 1f).SetEase(Ease.OutBack);
    }
    public void playButton()
    {
        if(PlayerPrefs.GetInt("soundControl")==1)
        {
            audioSource.PlayOneShot(buttonClick);
        }
        
        SceneManager.LoadScene("GameOptionsScene");
    }

   public void settingsButton()
    {
        
            if (soundControl.GetComponent<RectTransform>().localPosition == new Vector3(5, -39))
            {
            Debug.Log("burdayým");
                soundControl.GetComponent<RectTransform>().DOLocalMoveY(-92, 0.5f);
            }
            else
            {
                soundControl.GetComponent<RectTransform>().DOLocalMoveY(-39, 0.5f);
            }

        if (PlayerPrefs.GetInt("soundControl") == 1)
        {
            audioSource.PlayOneShot(buttonClick);
        }
    }

    public void exitButton()
    {
        if (PlayerPrefs.GetInt("soundControl") == 1)
        {
            audioSource.PlayOneShot(buttonClick);
        }
        Application.Quit();
    }
}
