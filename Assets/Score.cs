using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
    //TextMesh mesh;
    Text mesh = null;
    // Use this for initialization
    void Start () {
        mesh = GetComponent<Text>();
        string score = "\n" + Timer.minutes + " minutes and " + Timer.seconds + " seconds";
        if (mesh) { mesh.text += score; }
        
    }
	
}
