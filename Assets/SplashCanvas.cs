using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashCanvas : MonoBehaviour {
	void Awake()
	{
		DontDestroyOnLoad(gameObject);
	}

}
