using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    int val;
    void Start()
    {
        
        if (tag == "CoinBronze")
            val = 1;
        else
            if (tag == "CoinSilver")
            val = 5;
        else
            if (tag == "CoinGold")
            val = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerBehavior>().AddScore(val);
            Destroy(gameObject);
        }
    }
}
