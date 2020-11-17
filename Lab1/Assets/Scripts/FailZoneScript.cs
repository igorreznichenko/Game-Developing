using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailZoneScript : MonoBehaviour
{
    [SerializeField] GameObject player;
  

    // Update is called once per frame
 
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerBehavior>().GetDamage(100);
        }
        else
            if (collision.tag == "Enemy")
            collision.GetComponent<EnemyBehaviorScript>().GetDamage(100);
        else
            if (collision.tag == "DropPlatform")
            {
            collision.GetComponent<DropedPlatformBehaviorScript>().SetPosition();
            }
        else
            if(collision.tag == "Boss")
        {
            BossBehaviorScript boss = collision.GetComponent<BossBehaviorScript>();
            boss.GetDamage(200);
            boss.RenewPosition();
        }
           

    }
}
