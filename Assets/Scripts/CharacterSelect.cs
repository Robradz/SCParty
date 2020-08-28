using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UMA;
using UMA.CharacterSystem;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour
{
    [SerializeField] public GameObject[] characters = new GameObject[4];
    
    GamepadMove gamepadMove;

    [SerializeField] Camera selectionCamera;
    [SerializeField] Camera playerCamera;
    [SerializeField] Text nameCanvas;
    private PlayerInput playerInput;

    private int currentCharacter;
    private bool chosen = false;

    // Start is called before the first frame update
    void Start()
    {
        playerCamera.enabled = false;
        gamepadMove = GetComponent<GamepadMove>();
        playerInput = GetComponent<PlayerInput>();
        currentCharacter = 0;
        gamepadMove.animator = characters[currentCharacter].GetComponent<Animator>();
        SetTextPosition();
    }

    private void SetTextPosition()
    {
        RectTransform rectTransform = nameCanvas.GetComponent<RectTransform>();
        if (gameObject.name == "P1")
        {
            rectTransform.anchorMin = new Vector2(0.05f, .95f);
            rectTransform.anchorMax = new Vector2(0.05f, .95f);
            rectTransform.pivot = new Vector2(0.05f, .95f);
        } else if (gameObject.name == "P2")
        {
            rectTransform.anchorMin = new Vector2(.95f, .95f);
            rectTransform.anchorMax = new Vector2(.95f, .95f);
            rectTransform.pivot = new Vector2(.95f, .95f);
        } else if (gameObject.name == "P3")
        {
            rectTransform.anchorMin = new Vector2(0.05f, 0.05f);
            rectTransform.anchorMax = new Vector2(0.05f, 0.05f);
            rectTransform.pivot = new Vector2(0.05f, 0.05f);
        } else
        {
            rectTransform.anchorMin = new Vector2(.95f, 0.05f);
            rectTransform.anchorMax = new Vector2(.95f, 0.05f);
            rectTransform.pivot = new Vector2(.95f, 0.05f);
        }
    }

    private void Update()
    {
        nameCanvas.text = characters[currentCharacter].name;
    }

    private void OnChangeCharacter()
    {
        if(chosen) { return; }
        currentCharacter = (currentCharacter + 1) % 4;
        for (int i = 0; i < characters.Length; i++)
        {
            if (i != currentCharacter)
            {
                characters[i].SetActive(false);
            }
            else if (!characters[i].activeSelf)
            {
                characters[i].SetActive(true);
                gamepadMove.animator = characters[i].GetComponent<Animator>();
            }
        }
    }

    private void OnChooseCharacter()
    {
        if (selectionCamera != null)
        {
            selectionCamera.enabled = false;
            Destroy(selectionCamera);
        }
        playerCamera.enabled = true;
        playerInput.camera = playerCamera;
        PlayerCameraAlignment();
        gamepadMove.allowMovement = true;
        nameCanvas.enabled = false;
        chosen = true;
    }

    private void PlayerCameraAlignment()
    {
        if (gameObject.name == "P1")
        {
            playerCamera.rect = new Rect(0, .5f, .5f, .5f);
        }
        else if (gameObject.name == "P2")
        {
            playerCamera.rect = new Rect(.5f, .5f, .5f, .5f);
        }
        else if (gameObject.name == "P3")
        {
            playerCamera.rect = new Rect(0f, 0f, .5f, .5f);
        }
        else
        {
            playerCamera.rect = new Rect(.5f, 0f, .5f, .5f);
        }
    }
}
