using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Random;

public class LogicPuzzle : MonoBehaviour
{
    [SerializeField] Door door;

    [SerializeField] Text[] prices;
    [SerializeField] Text[] snacks;
    [SerializeField] Text[] drinks;

    [SerializeField] private Text clueText;
    [SerializeField] private Text answerText;
    [SerializeField] private Text gridNames;
    [SerializeField] private Text gridNames2;

    string[] names;
    string[] priceSolution;
    string[] snackSolution;
    string[] drinkSolution;

    // Start is called before the first frame update
    void Start()
    {
        names = new string[] { "Paul", "Tristan", "Robbie", "Joey" };
        names = RandomizeStringArray(names);
        AssignNames();
        priceSolution = new string[] { "5.99", "7.99", "6.99", "4.99"};
        drinkSolution = new string[] { "Slurpee", "Kombucha", "Coca-Cola", "Gatorade" };
        snackSolution = new string[] { "Big Bite", "Candy", "Taquitos", "Takis" };
    }

    

    // Update is called once per frame
    void Update()
    {
        bool correct = CheckSolution();
        if (correct)
        {
            door.GetComponent<MeshCollider>().enabled = false;
            door.GetComponent<MeshRenderer>().enabled = false;
            GetComponent<LogicPuzzle>().enabled = false;
        }
    }

    private bool CheckSolution()
    {
        for (int i = 0; i < priceSolution.Length; i++)
        {
            if (!(priceSolution[i] == prices[i].text && snackSolution[i] == snacks[i].text && drinkSolution[i] == drinks[i].text))
            {
                return false;
            }
        }
        return true;
    }

    private string[] RandomizeStringArray(string[] oldNames)
    {
        var newNames = new string[oldNames.Length];
        for (int i = 0; i < newNames.Length; i++)
        {
            int randomNumber = Range(0, oldNames.Length);
            while (oldNames[randomNumber] == null)
            {
                randomNumber = Range(0, oldNames.Length);
            }
            newNames[i] = oldNames[randomNumber];
            oldNames[randomNumber] = null;
        }
        return newNames;
    }
    
    private void AssignNames()
    {
        answerText.text = names[0] + "     " + names[1] + "     " + names[2] + "     " + names[3];
        clueText.text = 
            @"1.The one who got the kombucha paid more than the one who got the Coca-Cola
    2.The person who paid $5.99 didn't buy the Takis.
    3. " + names[2] + @" ordered the Taquitos.
    4. " + names[0] + @" paid less than the one who got the Coca-Cola.
    5.Of the person who paid $4.99 and " + names[0] + @", one got a big bite and the other bought Takis
    6.The one who got the Slurpee paid more than the one who got the Gatorade.
    7." + names[1] + " paid 1 dollar more than the person who ordered Taquitos.";
        gridNames.text = names[0] + "\n" + names[1] + "\n" + names[2] + "\n" + names[3];
        gridNames2.text = gridNames.text;
    }
}
