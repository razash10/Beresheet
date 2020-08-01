using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WelcomeText : MonoBehaviour {

	public static Text welcomeText;

	// Use this for initialization
	void Start () {
		welcomeText = GetComponent<Text>();
	}
	
}
