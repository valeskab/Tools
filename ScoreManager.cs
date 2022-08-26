using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int score; //Keep track of the score
    public TextMeshProUGUI scoreText; // Text object to be modified

    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreText();
    }

    // Update is called once per frame
    public void IncreaseScoreText(int amount)
    {
        score += amount;
        UpdateScoreText();
    }
    public void UpdateScoreText() // Updates the score every time coins are picked up
    {
        scoreText.text = "Score: "+ score;
    }
}