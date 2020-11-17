using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaBehaviorScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            collision.GetComponent<PlayerBehavior>().GetDamage(100);
        else
            if (collision.tag == "Enemy")
            collision.GetComponent<EnemyBehaviorScript>().GetDamage(100);
      
    }
}
