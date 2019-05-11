using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    #region FIELDS
    [SerializeField]
    GameObject ballPrefab;
    [SerializeField]
    float timeBetweenBalls = 3f;
    float timeSinceLastBall = 2f;
    #endregion


    #region METHODS
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastBall += Time.deltaTime;

        if (timeSinceLastBall >= timeBetweenBalls)
        {
            SpawnBall();
        }
    }

    void SpawnBall()
    {
        //spawn a ball
        //Instantiate a ball
        GameObject newBall = Instantiate(ballPrefab, this.transform.position, Quaternion.identity);
        //apply force to the ball with a slightly random angle downwards
        Vector2 trajectory = new Vector2(Random.Range(-.2f, .2f), -1);
        newBall.GetComponent<Rigidbody2D>().AddForce(trajectory*10, ForceMode2D.Impulse);

        timeSinceLastBall = 0f;
    }
    #endregion
}
