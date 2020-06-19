using UnityEngine;
using UnityEngine.SceneManagement;

public class Hint : MonoBehaviour {
    MeshRenderer meshOfHint;
    const float timeToShow = 60;
    public static float hintTimeCount = 0;
    int currentSceneIndex;

    // Use this for initialization
    void Start () {
        meshOfHint = GetComponent<MeshRenderer>();
        meshOfHint.enabled = false;
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
	
	// Update is called once per frame
	void Update () {
        hintTimeCount += Time.deltaTime;
        if (hintTimeCount >= timeToShow)
        {
            meshOfHint.enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.L) && meshOfHint.enabled)
        {
            hintTimeCount = 0;
            meshOfHint.enabled = false;
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
        
    }
}
