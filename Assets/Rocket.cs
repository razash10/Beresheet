using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    Rigidbody rigidBody;
    AudioSource thrustAudio;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
        thrustAudio = GetComponent<AudioSource>();
	}

    // Update is called once per frame
    void Update () {
        Thrust();
        Rotate();
    }

    private void Thrust()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rigidBody.AddRelativeForce(Vector3.up);
            if (!thrustAudio.isPlaying)
            {
                thrustAudio.Play();
            }
            print("Thrusting");
        }
        else
        {
            thrustAudio.Pause();
        }
    }

    private void Rotate()
    {
        rigidBody.freezeRotation = true; // take manual control of rotation

        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.forward);
        }

        if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            transform.Rotate(-Vector3.forward);
        }

        rigidBody.freezeRotation = false; // resume physics control of rotation
    }

    
}
