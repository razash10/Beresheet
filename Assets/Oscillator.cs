using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]

public class Oscillator : MonoBehaviour
{
    [SerializeField] Vector3 movementVector = new Vector3(10f,10f,10f);
    [SerializeField] float period = 2f;
    [SerializeField] float selfSpinSpeed = 0f;
    Vector3 selfSpinVector = Vector3.up;

    float movementFactor; // 0 for not moved, 1 for fully moved.
    Vector3 startingPos;
    float timeCounter = 0f;

    // Use this for initialization
    void Start()
    {
        startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(period <= Mathf.Epsilon) { return; }
        timeCounter += Time.deltaTime;
        float cycles = timeCounter / period; // grows continually from 0

        const float tau = Mathf.PI * 2f; // about 6.28
        float rawSinWave = Mathf.Sin(cycles * tau);

        movementFactor = rawSinWave / 2f + 0.5f;
        Vector3 offset = movementFactor * movementVector;
        transform.position = startingPos + offset;
        transform.Rotate(selfSpinVector * selfSpinSpeed * Time.deltaTime);
    }
}