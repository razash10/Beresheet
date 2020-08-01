using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
    Scene splashScene;
    Scene winnerScene;
    public static float timer;
    public static int minutes;
    public static int seconds;

    public static Text timerText;

    // Use this for initialization
    void Start () {
        splashScene = SceneManager.GetSceneByBuildIndex(0);
        timerText = GetComponent<Text>();
        timerText.enabled = false;
        timer = 0f;
	}
	
	// Update is called once per frame
	void Update () {
        Scene activeScene = SceneManager.GetActiveScene();
        
        if (Input.GetKeyDown(KeyCode.Space) && activeScene.Equals(splashScene))
        {
            timer = 0;
            WelcomeText.welcomeText.enabled = false;
            SceneManager.LoadScene(1);
        }

        if (timerText.enabled)
        {
            timer += Time.deltaTime;
            seconds = (int)Mathf.Abs(timer) % 60;
            minutes = (int)Mathf.Abs(timer) / 60;
            timerText = GetComponent<Text>();
            DisplayText();
        }

    }

    private void DisplayText()
    {
        if(minutes % 10 == minutes)
        {
            if(seconds % 10 == seconds)
            {
                timerText.text = "0" + minutes + ":" + "0" + seconds;
            }
            else
            {
                timerText.text = "0" + minutes + ":" + seconds;
            }
        }
        else
        {
            if (seconds % 10 == seconds)
            {
                timerText.text = minutes + ":" + "0" + seconds;
            }
            else
            {
                timerText.text = minutes + ":" + seconds;
            }
        }
    }
}
