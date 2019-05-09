using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    [SerializeField]
    int score = 0;
    [SerializeField]
    Text scoreText;
    [SerializeField]
    Text ballsLeftText;

    int ballsRemaining = 5;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score:  " + score;
        ballsLeftText.text = "Balls Left:  " + ballsRemaining;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RecordScore(int a)
    {
        score += a;
        scoreText.text = "Score:  " + score;
    }

    public void RecordLossOfBall()
    {
        ballsRemaining--;
        ballsLeftText.text = "Balls Left:  " + ballsRemaining;
    }
}
