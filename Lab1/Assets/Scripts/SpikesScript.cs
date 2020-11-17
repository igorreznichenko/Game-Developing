using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class SpikesScript : MonoBehaviour
{
   
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerBehavior>().GetDamage(1);
        }
    }
}
