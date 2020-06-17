using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularMotion : MonoBehaviour {
    [SerializeField] float speed = 5f;
    [SerializeField] float height = 5f;
    [SerializeField] float width = 5f;
    [SerializeField] bool invert = false;

    float x, y, z, timeCounter = 0f;
    Vector3 startingPos;

    // Use this for initialization
    void Start () {
        startingPos = transform.position;
        z = startingPos.z;

    }
	
	// Update is called once per frame
	void Update () {
        timeCounter += Time.deltaTime * speed;

        x = Mathf.Cos(timeCounter) * width;
        y = Mathf.Sin(timeCounter) * height;

        if (invert)
        {
            transform.position = startingPos + new Vector3(y, x, z);
        }
        else
        {
            transform.position = startingPos + new Vector3(x, y, z);
        }
        

    }
}
