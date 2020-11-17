using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackZoneScript : MonoBehaviour
{
    [SerializeField] float AttackArea;
    [SerializeField] Animator animator;
    int i = 0;
    public enum PlayerAttackType {sword, shield};

   
    public void PlayerAttack(int damage, PlayerAttackType t)
    {
        if (t == PlayerAttackType.sword)
            animator.SetTrigger("Attack");
        else
            if (t == PlayerAttackType.shield)
            animator.SetTrigger("IsBlock");
        Collider2D[] c = Physics2D.OverlapCircleAll(transform.position, AttackArea);
        foreach (var o in c)
        {
            if (o.tag == "Enemy" || o.tag == "Boss")
                o.GetComponent<EnemyBehaviorScript>().GetDamage(damage);
            
        } 
    }
   public void EnemyAttack(int damage)
   {
        animator.SetTrigger("Attack");
        Collider2D[] c = Physics2D.OverlapCircleAll(transform.position, AttackArea);
        foreach (var o in c)
        {
            if (o.tag == "Player")
                o.GetComponent<PlayerBehavior>().GetDamage(damage);

        }
   }
    public void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position,AttackArea);
    }

}
