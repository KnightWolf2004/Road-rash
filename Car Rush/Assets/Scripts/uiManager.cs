using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class uiManager : MonoBehaviour
{
    float time;
    public Button[] buttons;
    bool gameOver;
    public Text scoreText;
    int score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        InvokeRepeating("scoreUpdate", 1.0f, 1f);
        gameOver = false; 
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score;   
    }
    void scoreUpdate()
    {
        if (!gameOver)
        {
            score += 1;
        }
    }
    public void replay()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void menu()
    {
        SceneManager.LoadScene("MenuScene");
    }
    public void quit()
    {
        Application.Quit();
    }
    public void OnCollisionwith()
    {
        gameOver=true;
       foreach(Button button in buttons)
        {
            button.gameObject.SetActive(true);
        }
    }
    public void play()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void pause()
    {
        
        if(Time.timeScale >= 1)
        {
            time = Time.timeScale;
            Time.timeScale = 0;
        }
            
        else if(Time.timeScale == 0)
            Time.timeScale = time;
    }
}
