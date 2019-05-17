using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScoreText : MonoBehaviour
{
    [SerializeField]
    Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "SCORE: " + GameController.CurrentScore; 
    }

    
}
