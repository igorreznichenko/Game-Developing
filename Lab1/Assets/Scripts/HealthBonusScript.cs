using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBonusScript : MonoBehaviour
{
    [SerializeField] int amount = 40;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            collision.GetComponent<PlayerBehavior>().AddHealth(amount);
        Destroy(gameObject);
    }
}
