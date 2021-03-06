﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    #region FIELDS
    [SerializeField]
    GameObject ballPrefab;
    [SerializeField]
    float minTimeBetweenBalls;
    float maxTimeBetweenBalls;
    float nextTimeBetweenBalls;

    float timeSinceLastBall;
    GameObject newBall;
    #endregion


    #region METHODS
    // Start is called before the first frame update
    void Start()
    {
        minTimeBetweenBalls = ConfigurationUtils.MinBallSpawnTime;
        maxTimeBetweenBalls = ConfigurationUtils.MaxBallSpawnTime;
        nextTimeBetweenBalls = Random.Range(minTimeBetweenBalls, maxTimeBetweenBalls);
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastBall += Time.deltaTime;

        if (timeSinceLastBall >= nextTimeBetweenBalls)
        {
            SpawnBall();
            nextTimeBetweenBalls = Random.Range(minTimeBetweenBalls, maxTimeBetweenBalls);
        }
    }

    public void SpawnBall()
    {
        //spawn a ball
        //Instantiate a ball
        newBall = Instantiate(ballPrefab, this.transform.position, Quaternion.identity);
        newBall.GetComponent<Rigidbody2D>().isKinematic = true;
        Invoke("ReleaseBall", 1f);

        timeSinceLastBall = 0f;
    }

    void ReleaseBall()
    {
        //apply force to the ball with a slightly random angle downwards
        Vector2 trajectory = new Vector2(Random.Range(-.2f, .2f), -1);
        Rigidbody2D ballRig = newBall.GetComponent<Rigidbody2D>();
        ballRig.isKinematic = false;
        ballRig.AddForce(trajectory * 10, ForceMode2D.Impulse);
    }
    #endregion
}
