using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AvailableCharacters : MonoBehaviour
{
    public bool[] available = new bool[4];
    private bool doneChoosing;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        doneChoosing = true;
        foreach (bool boolean in available)
        {
            if (boolean == true)
            {
                doneChoosing = false;
                break;
            }
        }
    }
}
