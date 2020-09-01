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
        for (int i = 0; i < available.Length; i++)
        {
            available[i] = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        int readyCount = 0;
        for (int i = 0; i < available.Length; i++)
        {
            if (available[i] == false)
            {
                readyCount++;
            }
        }
        if (readyCount >= 3)
        {
            //SceneManager.LoadScene(1);
        }
    }
}
