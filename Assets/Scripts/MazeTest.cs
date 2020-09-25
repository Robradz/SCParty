using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using static UnityEngine.Random;
public class MazeTest : MonoBehaviour
{
    [SerializeField] private MazeDoor[] doors;
    [SerializeField] private Transform randomObject;
    [SerializeField] private Transform keyPrefab;
    private bool[] mazes;
    private int mazeNumber = 0;
    private int mazeCount = 1;
    private Transform key = null;

    // Start is called before the first frame update
    void Start()
    {
        mazes = new bool[3];
        for (int i = 0; i < mazes.Length; i++)
        {
            mazes[i] = true;
        }
    }

    private void NewMaze()
    {
        print(mazeNumber);
        MoveTrigger();

        for (int i = 0; i < doors.Length; i++)
        {
            if (mazeNumber == 1)
            {
                if (!doors[i].maze1)
                {
                    doors[i].GetComponentInChildren<Door>().GetComponent<MeshCollider>().enabled = false;
                    doors[i].GetComponentInChildren<Door>().GetComponent<MeshRenderer>().enabled = false;
                }
                else
                {
                    doors[i].GetComponentInChildren<Door>().GetComponent<MeshCollider>().enabled = true;
                    doors[i].GetComponentInChildren<Door>().GetComponent<MeshRenderer>().enabled = true;
                }
            }
            if (mazeNumber == 2)
            {
                if (!doors[i].maze2)
                {
                    doors[i].GetComponentInChildren<Door>().GetComponent<MeshCollider>().enabled = false;
                    doors[i].GetComponentInChildren<Door>().GetComponent<MeshRenderer>().enabled = false;
                }
                else
                {
                    doors[i].GetComponentInChildren<Door>().GetComponent<MeshCollider>().enabled = true;
                    doors[i].GetComponentInChildren<Door>().GetComponent<MeshRenderer>().enabled = true;
                }
            }
            if (mazeNumber == 3)
            {
                if (!doors[i].maze3)
                {
                    doors[i].GetComponentInChildren<Door>().GetComponent<MeshCollider>().enabled = false;
                    doors[i].GetComponentInChildren<Door>().GetComponent<MeshRenderer>().enabled = false;
                }
                else
                {
                    doors[i].GetComponentInChildren<Door>().GetComponent<MeshCollider>().enabled = true;
                    doors[i].GetComponentInChildren<Door>().GetComponent<MeshRenderer>().enabled = true;
                }
            }
        }

        mazeNumber = (mazeNumber + 1) % 3 + 1;
    }

    private void ClearDoors()
    {
        for (int i = 0; i < doors.Length; i++)
        {
            doors[i].GetComponentInChildren<Door>().GetComponent<MeshCollider>().enabled = false;
            doors[i].GetComponentInChildren<Door>().GetComponent<MeshRenderer>().enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(mazeNumber == 0)
        {
            mazeNumber = Math.Abs((int)randomObject.position.x % 3) + 1;
            NewMaze();
            return;
        }

        if (key != null)
        {
            Destroy(key.gameObject);
        }

        mazeCount++;
        if (mazeCount > 3)
        {
            ClearDoors();
        }
        else
        {
            NewMaze();
        }
    }

    private void MoveTrigger()
    {
        switch (mazeNumber)
        {
            case 1:
                GetComponent<BoxCollider>().center = new Vector3(75.2f, 4f, 179.7f);
                key = Instantiate(keyPrefab, new Vector3(113.8f, -28.48f, 58.665f), Quaternion.identity);
                break;
            case 2:
                GetComponent<BoxCollider>().center = new Vector3(69.37f, 4f, 156.6f);
                key = Instantiate(keyPrefab, new Vector3(104.31f, -28.48f, 20.78f), Quaternion.identity);
                break;
            case 3:
                GetComponent<BoxCollider>().center = new Vector3(40.5f, 4f, 138.7f);
                key = Instantiate(keyPrefab, new Vector3(56.36f, -28.48f, -9.25f), Quaternion.identity);
                break;
        }
    }
}
