using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class soundControlManager : MonoBehaviour
{
    
   
    void Start()
    {
        PlayerPrefs.SetInt("soundControl", 1);
    }

   
    
    public void soundOn()
    {
        PlayerPrefs.SetInt("soundControl", 1);
    }
    public void soundOff()
    {
        PlayerPrefs.SetInt("soundControl", 0);
    }
}
