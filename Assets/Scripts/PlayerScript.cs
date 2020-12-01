using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum powerups
{
    SteamSale,
    SadOnion,
    Heart,
    ToothPick,
    BloddyPenny,
    SoyMilk,
    DadsKey,
    IssacsFork,
    MothersKnife,
    Chad
}
public class PlayerScript : MonoBehaviour
{
    private powerups powers;
    private const float MAX_SPEED = 0.1f;
    private Vector3 speed = new Vector2(0.0f, 0.0f);
    private const float ACCELERATION = 0.001f;
    private float projectileTimer = 0.0f;
    private float projectileDelay = 1.0f;

    private bool[] powerUpsActive = new bool[10];
    public GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Player Init");
        for(int i = 0; i < powerUpsActive.Length;i++)
        {
            powerUpsActive[i] = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        projectileTimer += Time.deltaTime;
        inputHandler();
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
        projectileDelay = 1;

        GameObject tear = Instantiate(projectile, transform.position, Quaternion.identity);
        if (powerUpsActive[(int)powerups.SadOnion])
            projectileDelay -= 0.2f;
        if (powerUpsActive[(int)powerups.ToothPick])
        {
            projectileDelay -= 0.2f;
            tear.GetComponent<ProjectileScript>().setProjectileSpeed(1.2f);
        }
        if (powerUpsActive[(int)powerups.SoyMilk])
        {
            projectileDelay -= 0.5f;
            tear.GetComponent<ProjectileScript>().setProjectileDmg(0.2f);
        }
        if(powerUpsActive[(int)powerups.MothersKnife])
        {
            tear.GetComponent<ProjectileScript>().setProjectileDmg(2.0f);
        }

        tear.GetComponent<ProjectileScript>().setVelocity(velocity);
    }

    void inputHandler()
    {
        if (Input.GetKey(KeyCode.W))
        {
            speed = movePlayer(KeyCode.W);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            speed = movePlayer(KeyCode.A);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            speed = movePlayer(KeyCode.S);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            speed = movePlayer(KeyCode.D);
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
            playerShoot(new Vector3(0, 0.1f));
            projectileTimer = 0;
        }
        else if (Input.GetKey(KeyCode.DownArrow) && projectileTimer > projectileDelay)
        {
            playerShoot(new Vector3(0, -0.1f));
            projectileTimer = 0;
        }
        else if (Input.GetKey(KeyCode.RightArrow) && projectileTimer > projectileDelay)
        {
            playerShoot(new Vector3(0.1f, 0));
            projectileTimer = 0;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && projectileTimer > projectileDelay)
        {
            playerShoot(new Vector3(-0.1f, 0));
            projectileTimer = 0;
        }
    }

    public void powerUpSetTrue(int powerUp)
    {
        powerUpsActive[powerUp] = true;
    }
}
