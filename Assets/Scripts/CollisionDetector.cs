using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.tag == "Enemy")
        Destroy(collision.gameObject);
        
    }
}
