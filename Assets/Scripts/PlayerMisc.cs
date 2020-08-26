using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UMA;
using UMA.CharacterSystem;

public class PlayerMisc : MonoBehaviour
{
    private void Start()
    {
        gameObject.transform.parent = GameObject.Find("Players").transform;
        NamePlayer();
        GetComponent<GamepadMove>().allowMovement = false;
        GetComponent<CharacterSelect>().enabled = true;
    }

    private void NamePlayer()
    {
        gameObject.name = "P" + GameObject.Find("Players").transform.childCount.ToString();
        gameObject.transform.position = new Vector3(10, 0, 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
