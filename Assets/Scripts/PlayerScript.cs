using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum powerups
{
    SadOnion,
    Heart,
    ToothPick,
    SoyMilk,
    MothersKnife
}
public class PlayerScript : MonoBehaviour
{
    private powerups powers;
    private const float MAX_SPEED = 0.1f;
    private Vector3 speed = new Vector2(0.0f, 0.0f);
    private const float ACCELERATION = 0.05f;
    private float projectileTimer = 0.0f;
    private float projectileDelay = 1.0f;
    [SerializeField]
    public int playerHealth = 1;
    public int MAX_HEARTS = 3;
    public int playerBlackHealth = 3;
    public int MAX_BLACK_HEARTS = 3;

    public bool[] powerUpsActive = new bool[10];

    public GameObject projectile;
    private Rigidbody2D rgby;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < powerUpsActive.Length; i++)
        {
            powerUpsActive[i] = false;
        }
        rgby = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (PauseMenu.gamePaused == false)
        {
            projectileTimer += Time.deltaTime;
            inputHandler();
            speedThreshold();
            transform.position += speed;
        }
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
        powerUpsActivated(tear);
        tear.GetComponent<ProjectileScript>().setVelocity(velocity);
    }

    void inputHandler()
    {
        if (Input.GetKey(KeyCode.W))
        {
            speed = movePlayer(KeyCode.W);
            speedThreshold();
        }
        else if (Input.GetKey(KeyCode.A))
        {
            speed = movePlayer(KeyCode.A);
            speedThreshold();
        }
        else if (Input.GetKey(KeyCode.S))
        {
            speed = movePlayer(KeyCode.S);
            speedThreshold();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            speed = movePlayer(KeyCode.D);
            speedThreshold();
        }
        else
        {
            if (speed.x > 0)
                speed.x -= ACCELERATION;
            if (speed.y > 0)
                speed.y -= ACCELERATION;
            if (speed.x < 0)
                speed.x += ACCELERATION;
            if (speed.y < 0)
                speed.y += ACCELERATION;

        }

        if (Input.GetKey(KeyCode.UpArrow) && projectileTimer > projectileDelay)
        {
            playerShoot(new Vector3(0, 1.0f));
            projectileTimer = 0;
        }
        else if (Input.GetKey(KeyCode.DownArrow) && projectileTimer > projectileDelay)
        {
            playerShoot(new Vector3(0, -1.0f));
            projectileTimer = 0;
        }
        else if (Input.GetKey(KeyCode.RightArrow) && projectileTimer > projectileDelay)
        {
            playerShoot(new Vector3(1.0f, 0));
            projectileTimer = 0;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && projectileTimer > projectileDelay)
        {
            playerShoot(new Vector3(-1.0f, 0));
            projectileTimer = 0;
        }
    }

    public void powerUpSetTrue(int powerUp)
    {
        powerUpsActive[powerUp] = true;
    }

    private void powerUpsActivated(GameObject t_tear)
    {
        projectileDelay = 1;

        if (powerUpsActive[(int)powerups.SadOnion])
            projectileDelay -= 0.2f;
        if (powerUpsActive[(int)powerups.ToothPick])
        {
            projectileDelay -= 0.2f;
            t_tear.GetComponent<ProjectileScript>().setProjectileSpeed(1.2f);
        }
        if (powerUpsActive[(int)powerups.SoyMilk])
        {
            projectileDelay -= 0.5f;
            t_tear.GetComponent<ProjectileScript>().setProjectileDmg(0.2f);
        }
        if (powerUpsActive[(int)powerups.MothersKnife])
        {
            t_tear.GetComponent<ProjectileScript>().setProjectileDmg(2.0f);
        }
    }

    private void speedThreshold()
    {
        if (speed.x < 0.001 && speed.x > -0.001)
        {
            speed.x = 0;
        }
        if (speed.y < 0.001 && speed.y > -0.001)
        {
            speed.y = 0;
        }
    }
}
