using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    #region FIELDS
    [SerializeField]
    int points = 0;
    [SerializeField]
    int typeIndex;
    //BLOCK type 0 = standard, 1= bonus, 2 = freezer, 3 = speedup
    //enum Type { standard, bonus, freezer, speedup };
    GameController gameController;
        
        #endregion

    #region METHODS

    private void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ball"))
        {
            ActivateBlock();
        }
    }

    public void ActivateBlock()
    {
        if(typeIndex == 0)
        {
            //standard block behavior
            gameController.RecordScore(points);
        }
        else if(typeIndex == 1)
        {
            //bonus block behavior
            gameController.RecordScore(points * 2);
        }
        else if(typeIndex == 2)
        {
            //freezer block behavior
            Paddle paddle = FindObjectOfType<Paddle>();
            paddle.FreezePaddle();
        }
        else
        {
            //speedup block behavior
            //Find all the balls
            Ball[] balls = FindObjectsOfType<Ball>();
            foreach(Ball ball in balls)
            {
                ball.AddSpeedToBall();
            }
        }

        Destroy(this.gameObject);
    }
    #endregion
}
