using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {
    TextMesh mesh;
    // Use this for initialization
    void Start () {
        mesh = GetComponent<TextMesh>();
        string score = "\n" + Timer.minutes + " minutes and " + Timer.seconds + " seconds";
        mesh.text += score;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
