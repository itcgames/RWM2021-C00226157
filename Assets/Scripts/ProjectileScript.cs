using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    private Vector3 velocity = new Vector3 (0,0);

    // Update is called once per frame
    void Update()
    {
        transform.position += velocity;
    }

    public void setVelocity(Vector3 t_velocity)
    {
        velocity = t_velocity;
    }
}
