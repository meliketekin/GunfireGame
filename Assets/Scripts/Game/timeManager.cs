using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timeManager : MonoBehaviour
{
    [SerializeField]
    private Text timeText;
    [SerializeField]
    private GameObject finalPanel, circles, player, timeImage, trueFalse, upPanel, startImage;
   
    private void Start()
    {
        finalPanel.SetActive(false);
        circles.SetActive(true);
        player.SetActive(true);
        timeImage.SetActive(true);
        trueFalse.SetActive(true);
        upPanel.SetActive(true);
        startImage.SetActive(true);
    }




    public IEnumerator countTime()
    {
        for(int i=90; i>=0; i--)
        {
            if (i < 10)
            {
                timeText.text = "0" + i.ToString();
                yield return new WaitForSeconds(1f);
            }
            else
            {
                timeText.text = i.ToString();
                yield return new WaitForSeconds(1f);
            }
            if(i==0)
            {
                finalPanel.SetActive(true);
                cleanScreen();
            }
        }
    }
    void cleanScreen()
    {
        circles.SetActive(false);
        player.SetActive(false);
        timeImage.SetActive(false);
        trueFalse.SetActive(false);
        upPanel.SetActive(false);
        startImage.SetActive(false);
    }
}
