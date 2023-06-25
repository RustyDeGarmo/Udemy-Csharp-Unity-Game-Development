using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    float movementFactor;
    [SerializeField] float period = 2f;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(period <= Mathf.Epsilon){return;}
        float cycles = Time.time / period; //continually growing over time
        
        const float tau = Mathf.PI * 2; //constant ~6.283 to represent a circle
        float rawSinWave = Mathf.Sin(tau * cycles); //goes from -1 to 1 and back

        movementFactor = (rawSinWave + 1f) / 2f; 
        //add 1 to go from 0 to 2 instead of -1 to 1
        //divide by 2 to go from 0 to 1 instead of 0 to 2s
        //goes from 0 to 1 as a percentage of our movement vector
        //so it goes from 0% (original position) to 100% (new position)
        //new position is set in the movementVector in the inspector

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;
    }
}
