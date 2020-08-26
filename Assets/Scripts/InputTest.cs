using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class InputTest : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        var pim = GetComponent<PlayerInputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnPlayerJoined()
    {
        print("Player Joined");
    }

}
