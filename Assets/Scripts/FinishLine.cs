using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class FinishLine : MonoBehaviour
{

    Canvas finishCanvas;
    Text winnerText;

    // Start is called before the first frame update
    void Start()
    {
        finishCanvas = GetComponentInChildren<Canvas>();
        finishCanvas.enabled = false;
        winnerText = finishCanvas.GetComponentInChildren<Text>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) { return; }
        finishCanvas.enabled = true;
        winnerText.text = other.name + " wins!";
        Time.timeScale = 0;
    }
}
