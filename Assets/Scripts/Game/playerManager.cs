using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManager : MonoBehaviour
{
    [SerializeField]
    private Transform gun;
    [SerializeField]
    private GameObject[] ballPrefab;
    [SerializeField]
    private Transform ballPlace;
    [SerializeField]
    private AudioClip ballSound;
    [SerializeField]
    private AudioSource audioSource;
    float angle;
    float rotationSpeed = 5f;
    float between2ballsSpeed = 200f;
    float nextBall;
    public bool isRotate;

    private void Start()
    {
        isRotate = false;
    }
    // Update is called once per frame
    void Update()
    {
        if(isRotate)
        {
            changeRotation();
        }
        
    }
    void changeRotation()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition)-gun.transform.position;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg-90f;
        if(angle<45 && angle>-45)
        {
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            gun.transform.rotation = Quaternion.Slerp(gun.transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        }
        
        if(Input.GetMouseButtonDown(0))
        {
            if(Time.time>nextBall)
            {
                nextBall = Time.time + between2ballsSpeed / 1000;
                throwBall();
            }
        } 
    }
    void throwBall()
    {
        if (PlayerPrefs.GetInt("soundControl") == 1)
        {
            audioSource.PlayOneShot(ballSound);
        }
        GameObject cannonBall = Instantiate(ballPrefab[Random.Range(0, ballPrefab.Length)], ballPlace.position, ballPlace.rotation) as GameObject;
        
    }
}
