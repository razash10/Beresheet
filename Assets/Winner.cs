using UnityEngine;
using UnityEngine.SceneManagement;

public class Winner : MonoBehaviour {
    
    // Use this for initialization
    void Start () {
        Timer.timerText.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Timer.timer = 0f;
            SceneManager.LoadScene(1);
        }
    }
}
