using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigPotion : MonoBehaviour
{
    [SerializeField] GameObject[] bigPotionColors;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetColor(int colorNum)
    {
        for (int i = 0; i < bigPotionColors.Length; i++)
        {
            bigPotionColors[i].SetActive(i == colorNum);
        }
    }
}
