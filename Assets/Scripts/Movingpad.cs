using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movingpad : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        print("enter");
        other.transform.parent = transform;
    }

    private void OnTriggerExit(Collider other)
    {
        print("enter");
        other.transform.parent = FindObjectOfType<AvailableCharacters>().transform;
    }
}
