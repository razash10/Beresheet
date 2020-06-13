using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    Rigidbody rigidBody;
    AudioSource thrustAudio;
    [SerializeField] float rotationSpeed = 150f;
    [SerializeField] float thrustSpeed = 25f;

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

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                print("OK");
                break;
            default: // untagged
                print("dead");
                break;
        }
    }

    private void Thrust()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rigidBody.AddRelativeForce(Vector3.up * thrustSpeed);
            if (!thrustAudio.isPlaying)
            {
                thrustAudio.Play();
            }

        }
        else
        {
            thrustAudio.Pause();
        }
    }

    private void Rotate()
    {
        rigidBody.freezeRotation = true; // take manual control of rotation

        float rotationSpeedByFrame = rotationSpeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.forward * rotationSpeedByFrame);
        }

        if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            transform.Rotate(-Vector3.forward * rotationSpeedByFrame);
        }

        rigidBody.freezeRotation = false; // resume physics control of rotation
    }

    
}
