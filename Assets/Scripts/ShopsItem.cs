using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopsItem : MonoBehaviour
{
    public List<GameObject> allCollectables;
    private int randomItem;
    private TextMesh price;
    private int pricetag;
    private GameObject item;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        price = gameObject.GetComponent<TextMesh>();
        randomItem = Random.Range(0, 4);
        item = Instantiate(allCollectables[randomItem],gameObject.transform);
        item.tag = "ShopItem";
        item.transform.position += new Vector3(0.0f, -3.5f, 0.0f);
        pricetag = randomItem + 1;
        setPrice();
    }
    private void Update()
    {
        setPrice();
    }
    public void setPrice()
    {
            price.text = pricetag.ToString() + " c";
     
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            
            if (!doesThePlayerHaveThis())
            {
                    if (player.GetComponent<PlayerResourceManager>().getCoinCount() >= (int)(pricetag/2.0f))
                    {
                        item.tag = "Collectable";
                        player.GetComponent<PlayerResourceManager>().setCoinCount(player.GetComponent<PlayerResourceManager>().getCoinCount() - pricetag);
                    }
            }
            else
            {
                item.tag = "ShopItem";
            }
        }
    }

    private bool doesThePlayerHaveThis()
    {
        for (int i = 0; i < player.GetComponent<PlayerResourceManager>().getInventory().Count; i++)
        {
            if(item.name == player.GetComponent<PlayerResourceManager>().getInventory()[i].name)
            {
                return true;
            }
        }
        return false;
    }
}
