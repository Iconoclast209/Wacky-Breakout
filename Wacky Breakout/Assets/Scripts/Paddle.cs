using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    #region FIELDS
    [SerializeField]
    float speed = 0.4f;
    [SerializeField]
    float screenEdgeBuffer = 0.2f;

    Rigidbody2D rb2d;
    float halfColliderWidth;
    #endregion

    #region METHODS
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        halfColliderWidth = GetComponent<BoxCollider2D>().size.x / 2 + screenEdgeBuffer;
    }


    void FixedUpdate()
    {
        if(Input.GetAxis("Horizontal") > 0)
        {
            //Move Right
            Vector2 destination = new Vector2(transform.position.x, transform.position.y);
            destination += Vector2.right * speed * Input.GetAxis("Horizontal");
            if(destination.x + halfColliderWidth < ScreenUtils.ScreenRight)
            {
                rb2d.MovePosition(destination);
            }
                        
        }
        else if(Input.GetAxis("Horizontal") < 0)
        {
            //Move Left
            Vector2 destination = new Vector2(transform.position.x, transform.position.y);
            destination -= Vector2.left * speed * Input.GetAxis("Horizontal");
            if (destination.x - halfColliderWidth > ScreenUtils.ScreenLeft)
            {
                rb2d.MovePosition(destination);
            }
        }
    }
    #endregion

}
