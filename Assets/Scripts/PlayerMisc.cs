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
    [SerializeField] Camera playerCamera;
    public Vector3 originalPosition;
    private float lastHit = 0;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        characterController = GetComponent<CharacterController>();
        characterController.enabled = false;
        originalPosition = new Vector3(GameObject.Find("Players").transform.childCount * 10f, 1f, 0); //new Vector3(10f, 4f, 120f); new Vector3(-67f, 1f, 155f); new Vector3(GameObject.Find("Players").transform.childCount * 10f, 1f, 0);
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
        if (playerTransform.position.y <= -3.5)
        {
            playerTransform.position = originalPosition;
        }
        playerTransform.localScale = new Vector3(1,1,1);
    }

    //public static bool Raycast(Vector3 origin, Vector3 direction, out RaycastHit hitInfo, float maxDistance
    private void OnChooseCharacter() // This will also act as the action button
    {
        if(Time.time - lastHit < .25f)
        {
            return;
        } 
        else
        {
            lastHit = Time.time;
            RaycastHit hit;
            if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.TransformDirection(Vector3.forward), out hit, 200f))
            {
                try
                {
                    SmallPotion potion = hit.transform.GetComponent<SmallPotion>();
                    potion.ChangeColor();
                }
                catch { /* do nothing */ }

                try
                {
                    ButtonScript button = hit.transform.GetComponent<ButtonScript>();
                    button.ChangeOption();
                }
                catch { /* do nothing */ }

                try
                {
                    Boat boat = hit.transform.GetComponent<Boat>();
                    boat.SpinBoat();
                }
                catch { /* do nothing */ }
            }
        }
    }
}
