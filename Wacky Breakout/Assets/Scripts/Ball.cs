using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    float lifetime = 5f;
    float elapsedTime = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        //Tell GameController a new ball exists
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
}
