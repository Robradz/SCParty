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
    Vector3 originalPosition;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        characterController = GetComponent<CharacterController>();
        characterController.enabled = false;
        originalPosition = new Vector3(-42f, 4f, 260f); //new Vector3(GameObject.Find("Players").transform.childCount * 10f, 1f, 0);
        playerTransform.position = originalPosition;
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

    private void Update()
    {
        if (playerTransform.position.y <= -3)
        {
            playerTransform.position = originalPosition;
        }
        playerTransform.localScale = new Vector3(1,1,1);
    }
}
