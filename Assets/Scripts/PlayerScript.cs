using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private const float MAX_SPEED = 0.10f;
    private Vector3 speed = new Vector2(0.0f, 0.0f);
    private const float ACCELERATION = 0.01f;
    public GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            speed = movePlayer(KeyCode.W);
        }
        else if(Input.GetKey(KeyCode.A))
        {
            speed = movePlayer(KeyCode.A);
        }
        else if(Input.GetKey(KeyCode.S))
        {
            speed = movePlayer(KeyCode.S);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            speed = movePlayer(KeyCode.D);
        }

        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            playerShoot(new Vector3(0,0.1f));
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            playerShoot(new Vector3(0, -0.1f));
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            playerShoot(new Vector3(0.1f,0));
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            playerShoot(new Vector3(-0.1f,0));
        }

        transform.position += speed;
    }

    public Vector3 movePlayer(KeyCode t_input)
    {
        if (t_input == KeyCode.W)
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
        if (t_input == KeyCode.A)
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
        if (t_input == KeyCode.S)
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
        if (t_input == KeyCode.D)
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
        return speed;
    }

    void playerShoot(Vector3 velocity)
    {
        GameObject tear = Instantiate(projectile, transform.position, Quaternion.identity);
        tear.GetComponent<ProjectileScript>().setVelocity(velocity);
    }
}
