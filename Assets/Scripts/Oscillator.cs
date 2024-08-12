using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    float movementFactor;
    [SerializeField] float period = 2f;
    void Start()
    {
        startingPosition = transform.position;
        Debug.Log(startingPosition);
    }

    // Update is called once per frame
    void Update()
    {
        if (period != 0)
        {
            float cycles = Time.time / period;




            const float tau = Mathf.PI * 2;

            float rawSinWave = Mathf.Sin(cycles * tau);

            movementFactor = (rawSinWave + 1f) / 2f;

            Vector3 offset = movementVector * movementFactor;
            transform.position = startingPosition + offset;
        }
    }
}
