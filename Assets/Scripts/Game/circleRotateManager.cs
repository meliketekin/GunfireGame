using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class circleRotateManager : MonoBehaviour
{
    GameManager gameManager;
    int chosen;
    private void Awake()
    {
        gameManager = Object.FindObjectOfType<GameManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "ball")
        {
            this.gameObject.transform.DORotate(transform.eulerAngles + Quaternion.AngleAxis(45, Vector3.forward).eulerAngles, 0.5f);
            if(collision.gameObject!=null)
            {
                Destroy(collision.gameObject);
            }
            
            if(this.gameObject.name=="circle1")
            {
                chosen = int.Parse(GameObject.Find("leftText").GetComponent<Text>().text);
            }
            else if (this.gameObject.name == "circle2")
            {
                chosen = int.Parse(GameObject.Find("middleText").GetComponent<Text>().text);
            }
            else if (this.gameObject.name == "circle3")
            {
                chosen = int.Parse(GameObject.Find("rightText").GetComponent<Text>().text);
            }
            gameManager.checkResult(chosen);
            gameManager.printQuestion();

        }

    }




}
