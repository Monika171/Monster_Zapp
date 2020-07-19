using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class heartSpawner : MonoBehaviour
{
    public GameObject[] hearts;
    int heartNo;
    public float maxPos = 2.2f;
    public float delayTimer = 0.9f;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = delayTimer;   
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            Vector3 heartPos = new Vector3(UnityEngine.Random.Range(-2.2f, 2.2f), transform.position.y, transform.position.z);
            heartNo = UnityEngine.Random.Range(0,3);
            Instantiate(hearts[heartNo], heartPos, transform.rotation);
            timer = delayTimer;
        }
        
    }
}
