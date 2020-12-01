using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResourceManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> Inventory;
    [SerializeField]
    private int coinCount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Collectable")
        {
            switch(collision.gameObject.name)
            {
                case "Coin":
                    coinCount++;
                    break;
                case "Item":
                    Inventory.Add(collision.gameObject);
                    break;
                default:
                    break;

            }

            collision.gameObject.SetActive(false);
        }    
    }
}
