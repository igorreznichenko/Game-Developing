using System.Collections.Generic;
using UnityEngine;

public class BlueFlagScript : MonoBehaviour
{
    [SerializeField] LevelManagerScript LevelManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
         if (collision.gameObject.tag == "Player")
        {  
            LevelManager.SetActiveWinnerMenu();
        }
    }
}
