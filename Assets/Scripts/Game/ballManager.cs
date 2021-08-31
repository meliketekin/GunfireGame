using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballManager : MonoBehaviour
{
    float ballSpeed = 15f;
  
    void Start()
    {
       
    }

    
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * ballSpeed);
    }
}
