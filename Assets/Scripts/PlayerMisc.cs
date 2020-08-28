using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UMA;
using UMA.CharacterSystem;

public class PlayerMisc : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    CharacterController characterController;
    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        characterController.enabled = false;
        playerTransform.position = new Vector3(GameObject.Find("Players").transform.childCount * 10f, 0, 0);
        characterController.enabled = true;
        gameObject.transform.parent = GameObject.Find("Players").transform;
        NamePlayer();
        GetComponent<GamepadMove>().allowMovement = false;
        GetComponent<CharacterSelect>().enabled = true;
    }

    private void NamePlayer()
    {
        gameObject.name = "P" + GameObject.Find("Players").transform.childCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
