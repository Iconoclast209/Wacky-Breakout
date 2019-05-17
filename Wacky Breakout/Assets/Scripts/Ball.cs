using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    float lifetime;
    float elapsedTime = 0;
    GameController gameController;
    
    // Start is called before the first frame update
    void Start()
    {
        lifetime = ConfigurationUtils.BallLifetime;
        gameController = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if(elapsedTime > lifetime)
        {
            DestroyMe();
        }
    }

    void DestroyMe()
    {
        //Tell GameController this ball is gone
        Destroy(this.gameObject);
    }

    public void AddSpeedToBall()
    {
        //Figure this out
        Debug.Log("Adding speed to this ball.");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Wall"))
        {
            gameController.PlayBounceSFX();
        }
    }

}
