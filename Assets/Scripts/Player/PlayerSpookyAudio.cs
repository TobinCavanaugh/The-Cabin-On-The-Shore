using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerSpookyAudio : MonoBehaviour
{
    public Transform playerTransform;
    public GameObject audioSource;

    void Start()
    {
        InvokeRepeating("FlickerOn", Random.Range(0, 1), Random.Range(8, 15));
    }

    private void Update()
    {
        transform.position = playerTransform.position;
    }

    private void FlickerOn(){
        audioSource.SetActive(true);
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, Random.Range(-180, 180),
            transform.localEulerAngles.z);
        Invoke("FlickerOff", Random.Range(2, 5));
    }

    private void FlickerOff(){
        audioSource.SetActive(false);
    }
}
