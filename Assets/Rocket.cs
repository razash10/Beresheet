using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour {

    Rigidbody rigidBody;
    AudioSource thrustAudio;
    [SerializeField] float rotationSpeed = 150f;
    [SerializeField] float thrustSpeed = 25f;

    enum State { Dying, Alive, Transanding}
    State state = State.Alive;

    // Use this for initialization
    void Start () {
        rigidBody = GetComponent<Rigidbody>();
        thrustAudio = GetComponent<AudioSource>();
	}

    // Update is called once per frame
    void Update () {
        if(state == State.Alive)
        {
            Thrust();
            Rotate();
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(state != State.Alive) { return; }

        switch (collision.gameObject.tag)
        {
            case "Friendly":
                break;
            case "Finish":
                state = State.Transanding;
                Invoke("LoadNextScene", 0f);
                break;
            default: // "untagged"
                state = State.Dying;
                Invoke("LoadFirstScene", 0f);
                break;
        }
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(1);
    }

    private void LoadFirstScene()
    {
        SceneManager.LoadScene(0);
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
