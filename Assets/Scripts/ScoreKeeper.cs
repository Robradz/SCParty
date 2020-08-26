using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Player;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreKeeper : MonoBehaviour
{
    Dictionary<string, int> scores = new Dictionary<string, int>();

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);

        scores.Add("P1", 0);
        scores.Add("P2", 0);
        scores.Add("P3", 0);
        scores.Add("P4", 0);
    }

    public void IncrementScore(string playerName, int amount)
    {
        scores[playerName] += amount;
    }

    public List<string> GetWinner()
    {
        int highScore = scores["P1"];
        List<string> winners = new List<string>();
        winners.Add("P1");

        foreach (string name in scores.Keys)
        {
            if(scores[name] > highScore)
            {
                winners.Clear();
                winners.Add(name);
            }
            else if (scores[name] == highScore)
            {
                winners.Add(name);
            }
        }
        return winners;
    }
}
