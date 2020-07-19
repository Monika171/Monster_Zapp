using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class monsController : MonoBehaviour
{
    public float monsSpeed;    
    public float maxPos = 2.2f;

    Vector3 position;

    public uiManager ui;

    // Start is called before the first frame update
    void Start()
    {
        //ui = GetComponent<uiManager> ();
        position = transform.position; 
    }

    // Update is called once per frame
    void Update()
    {
        position.x += Input.GetAxis("Horizontal") * monsSpeed * Time.deltaTime;

        position.x = Mathf.Clamp (position.x, -2.2f, 2.2f);

        transform.position = position;
        

    }

    void OnCollisionEnter2D(Collision2D col) {

        if (col.gameObject.tag == "Enemy Heart")
        {
            Destroy(gameObject);
            ui.gameOverActivated();
        }
    }
}
