using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallPotion : MonoBehaviour
{

    [SerializeField] GameObject[] potionColors;
    public int currentColor;

    // Start is called before the first frame update
    void Start()
    {
        currentColor = 0;
    }

    public void ChangeColor()
    {
        currentColor = (currentColor + 1) % potionColors.Length;

        for (int i = 0; i < potionColors.Length; i++)
        {
            potionColors[i].SetActive(i == currentColor);
        }
    }
}
