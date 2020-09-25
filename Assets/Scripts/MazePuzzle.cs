using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using static UnityEngine.Random;

public class MazePuzzle : MonoBehaviour
{

    [SerializeField] BigPotion[] bigPotions;
    [SerializeField] SmallPotion[] smallPotions;

    [SerializeField] MazeDoor exit;

    [SerializeField] int[] solution;
    [SerializeField] int[] proposed;

    // Start is called before the first frame update
    void Start()
    {
        proposed = new int[smallPotions.Length];
        SetSolution();
    }

    private void SetSolution()
    {
        solution = new int[bigPotions.Length];

        for (int i = 0; i < solution.Length; i++)
        {
            solution[i] = Range(0,3);
            bigPotions[i].SetColor(solution[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        bool correct = true; 
        for (int i = 0; i < smallPotions.Length; i++)
        {
            proposed[i] = smallPotions[i].currentColor;
        }

        for (int i = 0; i < smallPotions.Length; i++)
        {
            if (proposed[i] != solution[i])
            {
                correct = false;
                break;
            }
        }

        if (correct)
        {
            exit.GetComponentInChildren<Door>().GetComponent<MeshCollider>().enabled = false;
            exit.GetComponentInChildren<Door>().GetComponent<MeshRenderer>().enabled = false;
            GetComponent<MazePuzzle>().enabled = false;
        }
    }
}
