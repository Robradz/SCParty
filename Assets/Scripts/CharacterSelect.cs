using System.Collections;
using System.Collections.Generic;
using UMA;
using UMA.CharacterSystem;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterSelect : MonoBehaviour
{

    Vector2 i_movement;

    [SerializeField] Camera playerCamera;

    [SerializeField] UMADynamicCharacterAvatarRecipe[] characters = new UMADynamicCharacterAvatarRecipe[4]; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // DisplayAvailableCharacters();
    }

    private void OnMove(InputValue value)
    {
        i_movement = value.Get<Vector2>();
        // Change through the .assets connected to the Dynamic Avatar or something
    }

    private void OnChooseCharacter()
    {
        // Make Camera in FPS view
    }

}
