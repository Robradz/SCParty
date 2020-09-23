using System.Runtime.CompilerServices;
using UnityEngine;
using static UnityEngine.Random;

public class Maze : MonoBehaviour
{
    /*int mazeCount = 1;
    private int mazeNumber;
    private bool[] mazes;
    MazeDoor[] doors;
    
    // Start is called before the first frame update
    void Start()
    {
        mazes = new bool[3];
        for (int i = 0; i < mazes.Length; i++)
        {
            mazes[i] = true;
        }
        var doors = FindObjectsOfType<MazeDoor>();
        NewMaze();
    }

    private void OnTriggerEnter(Collider other)
    {
        mazeCount++;
        if (mazeCount >= 3)
        {
            ClearDoors();
        }
        else
        {
            NewMaze();
        }
    }

    private void ClearDoors()
    {
        MazeDoor[] doors = FindObjectsOfType<MazeDoor>();
        foreach (MazeDoor door in doors)
        {
            door.GetComponentInChildren<Door>().enabled = false;
        }
    }

    private void NewMaze()
    {
        mazeNumber = Range(1, 3);

        while (!mazes[mazeNumber - 1])
        {
            mazeNumber = Range(1, 3);
        }

        mazes[mazeNumber - 1] = false; 

        foreach (MazeDoor door in doors)
        {
            print(door);
            print(door.GetComponentInChildren<Door>());

            if (mazeNumber == 1)
            {
                if (door.maze1)
                {
                    door.GetComponentInChildren<Door>().enabled = true;
                }
                else
                {
                    door.GetComponentInChildren<Door>().enabled = false;
                }
            }

            if (mazeNumber == 2)
            {
                if (door.maze2)
                {
                    door.GetComponentInChildren<Door>().enabled = true;
                }
                else
                {
                    door.GetComponentInChildren<Door>().enabled = false;
                }
            }

            if (mazeNumber == 3)
            {
                if (door.maze3)
                {
                    door.GetComponentInChildren<Door>().enabled = true;
                }
                else
                {
                    door.GetComponentInChildren<Door>().enabled = false;
                }
            }
        }
    }*/
}
