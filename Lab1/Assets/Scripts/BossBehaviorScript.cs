using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossBehaviorScript : EnemyBehaviorScript
{
 
    [SerializeField] GameObject respawn;
    [SerializeField] Slider slider;
    [SerializeField] GameObject panel;
    [SerializeField] LevelManagerScript levelManager;
   
    public override void Start()
    {
        base.Start();
        slider.maxValue = Health;
        slider.value = Health;
        panel.SetActive(false);
    }
    public override void FollowingPlayer()
    {
        base.FollowingPlayer();
        if (!panel.active)
        {
            panel.SetActive(true);
        }
    }
    public override void GetDamage(int damage)
    {
        
        StartCoroutine(getDamage(damage));
    }
    public void RenewPosition()
    {
        transform.position = respawn.transform.position;
    }
  
    public IEnumerator getDamage(int damage)
    {

        health -= damage;
        slider.value = health;
        if (health <= 0)
        {
            health = 0;
            animator.SetBool("Killed", true);
            enabled = false;
            yield return new WaitForSeconds(0.9f);
            Destroy(gameObject);
            levelManager.SetActiveWinnerMenu();
        }
    }
    
   
}
