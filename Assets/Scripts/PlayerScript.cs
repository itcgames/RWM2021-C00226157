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

    public GameObject HudCoins;
    public GameObject HudBombs;

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

    private bool[] powerUpsActive = new bool[10];

    public GameObject projectile;
    public Animator animator;
    private Rigidbody2D rgby;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < powerUpsActive.Length; i++)
        {
            powerUpsActive[i] = false;
        }

        gameObject.GetComponent<Health>().health = playerHealth;
        gameObject.GetComponent<Health>().blackHealth = playerBlackHealth;
        gameObject.GetComponent<Health>().numOfHearts = MAX_HEARTS;
        gameObject.GetComponent<Health>().numOfBlackHearts = MAX_BLACK_HEARTS;

        HudCoins.GetComponent<Consumable>().setAmount(gameObject.GetComponent<PlayerResourceManager>().getCoinCount());
        HudBombs.GetComponent<Consumable>().setAmount(gameObject.GetComponent<PlayerResourceManager>().getBombCount());

        animator = gameObject.GetComponent<Animator>();
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

            HudCoins.GetComponent<Consumable>().setAmount(gameObject.GetComponent<PlayerResourceManager>().getCoinCount());
            HudBombs.GetComponent<Consumable>().setAmount(gameObject.GetComponent<PlayerResourceManager>().getBombCount());
        }
    }

    public Vector3 movePlayer(KeyCode t_input)
    {
        if (t_input == KeyCode.W)
        {
            animator.SetBool("moveUp", true);
            animator.SetBool("Idle", false);

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
        else
        {
            animator.SetBool("moveUp", false);
        }

        if (t_input == KeyCode.A)
        {
            animator.SetBool("moveLeft", true);
            animator.SetBool("Idle", false);

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
        else
        {
            animator.SetBool("moveLeft", false);
        }

        if (t_input == KeyCode.S)
        {
            animator.SetBool("moveDown", true);
            animator.SetBool("Idle", false);

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
        else
        {
            animator.SetBool("moveDown", false);
        }

        if (t_input == KeyCode.D)
        {
            animator.SetBool("moveRight", true);
            animator.SetBool("Idle", false);

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
        else
        {
            animator.SetBool("moveRight", false);
        }

        if (speed == Vector3.zero)
        {
            animator.SetBool("Idle", true);
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

    public float getHealth()
    {
        return playerHealth;
    }

    public void increasePlayerHealth()
    {
        if (playerHealth < MAX_HEARTS)
        {
            playerHealth++;
        }

        gameObject.GetComponent<Health>().health = playerHealth;

    }

    public void increasePlayerBlackHealth()
    {
        if (playerBlackHealth < MAX_BLACK_HEARTS)
        {
            playerBlackHealth++;
        }

        gameObject.GetComponent<Health>().blackHealth = playerBlackHealth;
    }

    public void increaseMaxHealth(int num = 1)
    {
        gameObject.GetComponent<Health>().setMaxHeart(MAX_HEARTS + num);

        MAX_HEARTS = MAX_HEARTS + num;
    }

    public void increaseMaxBlackHeart(int num = 1)
    {
        gameObject.GetComponent<Health>().setMaxBlackHeart(MAX_BLACK_HEARTS + num);

        MAX_BLACK_HEARTS = MAX_BLACK_HEARTS + num;
    }

    public void decreaseHealth()
    {
        if (playerBlackHealth >= 0)
        {
            playerBlackHealth--;
        }
        else if (playerHealth >= 0)
        {
            playerHealth--;
        }

        gameObject.GetComponent<Health>().health = playerHealth;
        gameObject.GetComponent<Health>().blackHealth = playerBlackHealth;
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
