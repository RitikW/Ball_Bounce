using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D player;
  
    [SerializeField]
    private float speed;
    [SerializeField]
    private float jumpforce;

    private bool is_left;
    private bool is_right;
    private bool is_jumping;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(is_left == true)
        {
            left();
        }
        else if(is_right == true)
        {
            right();
        }
    }
    public void _left(bool _isleft)
    {
        is_left = _isleft;
    }
    public void _right(bool _isright)
    {
        is_right = _isright;
    }

    public void left()
    {
        player.velocity = new Vector2(-speed ,player.velocity.y);
    }

    public void right()
    {
        player.velocity = new Vector2(speed ,player.velocity.y);
    }

    public void jump()
    {
        if(is_jumping)
        {
            player.velocity = new Vector2(player.velocity.x, jumpforce);
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            is_jumping = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            is_jumping = false;
        }
    }
    
}
