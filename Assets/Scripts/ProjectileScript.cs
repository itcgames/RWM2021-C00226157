using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    [SerializeField]
    private Vector3 velocity = new Vector3 (0,0);
    [SerializeField]
    private float speed = 1.0f;
    [SerializeField]
    private float damage = 1.0f;

    // Update is called once per frame
    void Update()
    {
        transform.position += velocity * speed;
    }

    public void setVelocity(Vector3 t_velocity)
    {
        velocity = t_velocity;
    }

    public float getProjectileDmg()
    {
        return damage;
    }

    public void setProjectileDmg(float t_dmg)
    {
        if (damage >= 0.1)
        {
            damage = damage * t_dmg;
        }
    }

    public void setProjectileSpeed(float t_speed)
    {
        if (speed >= 0.1)
        {
            speed = t_speed;
        }
    }
}
