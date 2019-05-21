using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottom : MonoBehaviour
{
    GameController gameController;
    BallSpawner ballSpawner;
    
    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        ballSpawner = FindObjectOfType<BallSpawner>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Ball"))
        {
            gameController.RecordLossOfBall();
            ballSpawner.SpawnBall();
            Destroy(collision.gameObject);
        }
    }
}
