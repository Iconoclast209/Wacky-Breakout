using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    #region FIELDS
    int points = 0;
    [SerializeField]
    int typeIndex;  //BLOCK type 0 = standard, 1= bonus, 2 = freezer, 3 = speedup
    GameController gameController;
    #endregion

    #region METHODS

    private void Start()
    {
        DeterminePoints();
        gameController = FindObjectOfType<GameController>();
        gameController.AddBlock();
    }

    private void DeterminePoints()
    {
        if (typeIndex == 0 || typeIndex == 1)
        {
            //Standard or Bonus Block Points
            points = ConfigurationUtils.PointsStandard;
        }

        else if (typeIndex == 2)
        {
            //Freezer Block Points
            points = ConfigurationUtils.PointsFreezer;
        }
        else
        {
            //Speedup Block Points
            points = ConfigurationUtils.PointsSpeedup;
        }
    }
    
     void OnCollisionEnter2D(Collision2D collision)
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
            //Paddle paddle = FindObjectOfType<Paddle>();
            //paddle.FreezePaddle();
            gameController.RecordScore(points);
        }
        else
        {
            //speedup block behavior
            gameController.RecordScore(points);
            //Find all the balls
            /*
            Ball[] balls = FindObjectsOfType<Ball>();
            foreach(Ball ball in balls)
            {
                ball.AddSpeedToBall();
            }
            */
        }
        gameController.BlockDestroyed();
        Destroy(this.gameObject);
    }
    #endregion
}
