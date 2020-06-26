using UnityEngine;
using UnityEngine.SceneManagement;

public class Winner : MonoBehaviour {
    
    // Use this for initialization
    void Start () {
        Timer.timerRender.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Timer.timer = 0f;
            Timer.timerRender.enabled = true;
            SceneManager.LoadScene(1);
        }
    }
}
