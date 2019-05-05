using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    #region FIELDS
    [SerializeField]
    float speed = 0.4f;
    [SerializeField]
    float screenEdgeBuffer = 0.1f;

    Rigidbody2D rb2d;
    float halfColliderWidth;
    #endregion

    #region METHODS
    
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        halfColliderWidth = GetComponent<BoxCollider2D>().size.x / 2;
    }

    void FixedUpdate()
    {
        if(Input.GetAxis("Horizontal") != 0)
        {
            Vector2 destination = new Vector2(transform.position.x, transform.position.y);
            destination += Vector2.right * speed * Input.GetAxis("Horizontal");
            destination.x = Mathf.Clamp(destination.x, ScreenUtils.ScreenLeft + halfColliderWidth + screenEdgeBuffer,
                ScreenUtils.ScreenRight - halfColliderWidth - screenEdgeBuffer);
            rb2d.MovePosition(destination);
        }
    }
    #endregion

}
