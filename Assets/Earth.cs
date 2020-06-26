using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth : MonoBehaviour {
    [SerializeField] float period = 2f;
    [SerializeField] float selfSpinSpeed = 0f;
    Vector3 selfSpinVector = Vector3.up;
    Vector3 startingPos;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (period <= Mathf.Epsilon) { return; }
        float cycles = Time.time / period; // grows continually from 0
        transform.Rotate(selfSpinVector * selfSpinSpeed * Time.deltaTime);
    }
}
