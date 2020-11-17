using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpeedBonusScript : MonoBehaviour
{
    int speedBonus = 5;
    float duration = 5;

    [SerializeField] LevelManagerScript levelManager;
    Collider2D player;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerBehavior>().ChangeSpeed(speedBonus, duration);
            Destroy(gameObject);
        }
    }


}
