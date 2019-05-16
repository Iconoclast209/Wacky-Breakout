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
    [SerializeField]
    int blocksRemaining = 0;
    [SerializeField]
    int ballsRemaining = 5;

    LevelManager levelManager;


    // Start is called before the first frame update
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
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
        if(ballsRemaining <= 0)
        {
            EndGame();
        }
        ballsLeftText.text = "Balls Left:  " + ballsRemaining;
    }
    
    public void AddBlock()
    {
        blocksRemaining++;
    }

    public void BlockDestroyed()
    {
        blocksRemaining--;
        if(blocksRemaining <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        levelManager.LoadNextLevel();
        Debug.Log("Game Ended");
    }

}
