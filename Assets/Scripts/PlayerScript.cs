using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private const float MAX_SPEED = 1.0f;
    private Vector3 speed = new Vector2(0.0f, 0.0f);
    private const float ACCELERATION = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            speed = movePlayer(KeyCode.W);
        }
        if(Input.GetKeyDown(KeyCode.A))
        {
            speed = movePlayer(KeyCode.A);
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            speed = movePlayer(KeyCode.S);
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            speed = movePlayer(KeyCode.D);
        }

        transform.position += speed;
    }

    public Vector3 movePlayer(KeyCode t_input)
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (speed.y < MAX_SPEED)
            {
                speed.y += ACCELERATION;
            }
            if (speed.x < 0)
            {
                speed.x += ACCELERATION;
            }
            if (speed.x > 0)
            {
                speed.x -= ACCELERATION;
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (speed.x > -MAX_SPEED)
            {
                speed.x -= ACCELERATION;
            }
            if (speed.y < 0)
            {
                speed.y += ACCELERATION;
            }
            if (speed.y > 0)
            {
                speed.y -= ACCELERATION;
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (speed.y > -MAX_SPEED)
            {
                speed.y -= ACCELERATION;
            }
            if (speed.x < 0)
            {
                speed.x += ACCELERATION;
            }
            if (speed.x > 0)
            {
                speed.x -= ACCELERATION;
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (speed.x < MAX_SPEED)
            {
                speed.x += ACCELERATION;
            }
            if (speed.y < 0)
            {
                speed.y += ACCELERATION;
            }
            if (speed.y > 0)
            {
                speed.y -= ACCELERATION;
            }
        }

        transform.position += speed;
        return speed;
    }
}
