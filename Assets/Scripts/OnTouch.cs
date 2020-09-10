using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTouch : MonoBehaviour
{
    private Oscillator oscillator;
    public GameObject player;
    private bool moving;
    Vector3 startPos;

    private void Start()
    {
        oscillator = GetComponent<Oscillator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        startPos = other.transform.position;
        if (other.gameObject.CompareTag("Player"))
        {
            moving = true;
            other.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            moving = false;
            other.transform.parent = FindObjectOfType<AvailableCharacters>().transform;
        }
    }
}
