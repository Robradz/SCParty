using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] Text buttonText;

    [Header("Button Type")]
    [SerializeField] bool price;
    [SerializeField] bool snack;
    [SerializeField] bool drink;

    string[] options;

    int currentOption = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (price)
        {
            options = new string[] { "4.99", "5.99", "6.99", "7.99" };
        } 
        else if (snack)
        {
            options = new string[] { "Big Bite", "Taquitos", "Takis", "Candy" };
        }
        else if (drink)
        {
            options = new string[] { "Slurpee", "Kombucha", "Coca-Cola", "Gatorade" };
        }

        buttonText.text = options[currentOption];
    }

    public void ChangeOption()
    {
        currentOption = (currentOption + 1) % options.Length;
        buttonText.text = options[currentOption];
    }

    public string GetChoice() 
    {
        return options[currentOption];
    }
}
