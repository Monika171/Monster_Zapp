using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class uiManager : MonoBehaviour
{
    public Button[] buttons;
    public Text scoreText;
    public AudioManager am;
    int score;
    bool gameOver;
    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        score = 0;
        InvokeRepeating("scoreUpdate", 1.0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name!="menuScene")
        {
            scoreText.text = "Score: " + score;
        }
    }

    void scoreUpdate()
    {
        if (!gameOver)
        {
            score += 1;
        }
    }

    public void gameOverActivated()
    {
        gameOver = true;
        foreach(Button button in buttons)
        {
            button.gameObject.SetActive(true);
        }
    }

    public void Play()
    {
        SceneManager.LoadScene("level1");
    }

    public void Pause()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            am.monsSound.Stop();
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            am.monsSound.Play();
        }
    }

    public void Menu()
    {
        SceneManager.LoadScene("menuScene");
    }

    public void exit()
    {
        
#if UNITY_EDITOR
        
         UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

}
