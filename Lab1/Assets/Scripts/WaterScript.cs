using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WaterScript : MonoBehaviour
{

    List<Collider2D> entities = new List<Collider2D>();
    float currenttime;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
      
        if (collision.tag == "Player" || collision.tag == "Enemy")
        {
            entities.Add(collision);
            currenttime = Time.time + 1f;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Player Exit");
        entities.Remove(collision);
    }

    private void Update()
    {
        if (entities.Count > 0 && currenttime < Time.time)
        {
            int health;
            int i = 0;
            do
            {
                if (entities[i].tag == "Player")
                {       
                    entities[i].GetComponent<PlayerBehavior>().GetDamage(10);
                    health = entities[i].GetComponent<PlayerBehavior>().Health;
                }
                else
                {
                    entities[i].GetComponent<EnemyBehaviorScript>().GetDamage(10);
                    health = entities[i].GetComponent<EnemyBehaviorScript>().Health;

                }
                if (health == 0)
                    entities.RemoveAt(i);
                else
                    i++;
                Debug.Log(i);
               
            } while (i < entities.Count);
            currenttime += 1f;
        }
    }
}
