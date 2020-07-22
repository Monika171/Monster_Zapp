using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class monsController : MonoBehaviour
{
    public float monsSpeed;    
    public float maxPos = 2.2f;

    Vector3 position;

    public uiManager ui;
    public AudioManager am;

    bool currentPlatformAndroid = false;

    Rigidbody2D rb;

    // Start is called before the first frame update

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        #if UNITY_ANDROID
                currentPlatformAndroid = true;
        #else
                currentPlatformAndroid = false;
        #endif

        am.monsSound.Play();
    }
    void Start()
    {         
        position = transform.position; 

        if (currentPlatformAndroid == true)
        {
            UnityEngine.Debug.Log("Android");
        }
        else
        {
            UnityEngine.Debug.Log("Windows");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentPlatformAndroid == true)
        {
            TouchMove();
        }

        else
        {
            position.x += Input.GetAxis("Horizontal") * monsSpeed * Time.deltaTime;
            position.x = Mathf.Clamp(position.x, -2.2f, 2.2f);
            transform.position = position;
        }

        position = transform.position;
        position.x = Mathf.Clamp(position.x, -2.2f, 2.2f);
        transform.position = position;
    }

    void OnCollisionEnter2D(Collision2D col) {

        if (col.gameObject.tag == "Enemy Heart")
        {
            //Destroy(gameObject);
            gameObject.SetActive(false);
            ui.gameOverActivated();
            am.monsSound.Stop();
        }
    }

    void TouchMove()
    {
    if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            float middle = Screen.width / 2;

            if(touch.position.x < middle && touch.phase == TouchPhase.Began)
            {
                MoveLeft();
            }

            else if (touch.position.x > middle && touch.phase == TouchPhase.Began)
            {
                MoveRight();
            }

            else
            {
                SetVelocityZero();
            }
        }
    }

    public void MoveLeft()
    {
        rb.velocity = new Vector2(-monsSpeed, 0);
    }

    public void MoveRight()
    {
        rb.velocity = new Vector2 (monsSpeed,0);
    }

    public void SetVelocityZero()
    {
        rb.velocity = Vector2.zero;
    }
}
