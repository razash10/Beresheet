using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {
    Scene splashScene;
    Scene winnerScene;
    public static float timer;
    public static int minutes;
    public static int seconds;
    TextMesh timerText;
    public static MeshRenderer timerRender;
    
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start () {
        splashScene = SceneManager.GetSceneByBuildIndex(0);
        timerText = GetComponent<TextMesh>();
        timerRender = GetComponent<MeshRenderer>();
        timerRender.enabled = false;
        timer = 0f;
	}
	
	// Update is called once per frame
	void Update () {
        Scene activeScene = SceneManager.GetActiveScene();
        
        if (Input.GetKeyDown(KeyCode.Space) && activeScene.Equals(splashScene))
        {
            timer = 0;
            SceneManager.LoadScene(1);
        }

        if (timerRender.enabled)
        {
            timer += Time.deltaTime;
            seconds = (int)Mathf.Abs(timer) % 60;
            minutes = (int)Mathf.Abs(timer) / 60;
            timerText = GetComponent<TextMesh>();
            timerText.text = minutes + ":" + seconds;
        }

    }
}
