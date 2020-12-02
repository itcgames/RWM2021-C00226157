using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResourceManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> Inventory;
    [SerializeField]
    private int coinCount;
    [SerializeField]
    private int bombCount;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Collectable")
        {
            switch(collision.gameObject.name)
            {
                case "Coin":
                    coinCount++;
                    break;
                case "Bomb":
                    bombCount++;
                    break;
                case "Heart":
                    gameObject.GetComponent<PlayerScript>().increasePlayerHealth();
                    break;
                case "SadOnion":
                    Inventory.Add(collision.gameObject);
                    gameObject.GetComponent<PlayerScript>().powerUpSetTrue((int)powerups.SadOnion);
                    break;
                case "ToothPick":
                    Inventory.Add(collision.gameObject);
                    gameObject.GetComponent<PlayerScript>().powerUpSetTrue((int)powerups.ToothPick);
                    break;
                case "SoyMilk":
                    Inventory.Add(collision.gameObject);
                    gameObject.GetComponent<PlayerScript>().powerUpSetTrue((int)powerups.SoyMilk);
                    break;
                case "MothersKnife":
                    Inventory.Add(collision.gameObject);
                    gameObject.GetComponent<PlayerScript>().powerUpSetTrue((int)powerups.MothersKnife);
                    break;
                default:
                    break;

            }

            collision.gameObject.SetActive(false);
        }    
    }
}
