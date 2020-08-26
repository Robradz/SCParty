using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UMA;
using UMA.CharacterSystem;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterSelect : MonoBehaviour
{
    [SerializeField] public GameObject[] characters = new GameObject[4];
    
    Vector2 i_movement;
    private DynamicCharacterAvatar dynamicCharacterAvatar;
    private PlayerMisc playerMisc;
    GamepadMove gamepadMove;

    [SerializeField] Camera playerCamera;

    private int currentCharacter = 0;
    private float timeOfLastSwitch = 0;

    // Start is called before the first frame update
    void Start()
    {
        dynamicCharacterAvatar = GetComponentInChildren<DynamicCharacterAvatar>();
        playerMisc = GetComponent<PlayerMisc>();
        gamepadMove = GetComponent<GamepadMove>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < characters.Length - 1; i++)
        {
            if (i != currentCharacter) // && characters[i].activeSelf)
            {
                characters[i].SetActive(false);
            }
            else //if (!characters[i].activeSelf)
            {
                characters[i].SetActive(true);
                gamepadMove.animator = characters[i].GetComponent<Animator>();
            }
        }
        print(currentCharacter);
    }

    private void OnMove(InputValue value)
    {
        i_movement = value.Get<Vector2>();
        
        if (timeOfLastSwitch > Time.time - 1f)
        {
            return;
        }
        else
        {
            timeOfLastSwitch = Time.time;
        }

        if (i_movement.x < 0)
        {
            currentCharacter = (currentCharacter + 5) % 4;
        }
        else if (i_movement.x > 0)
        {
            currentCharacter = (currentCharacter + 1) % 4; ;
        }
    }

    private void OnChooseCharacter()
    {
        // Make Camera in FPS view
    }

}
