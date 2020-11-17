using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviorScript : MonoBehaviour
{
 
    [SerializeField] protected Transform Player;
    [SerializeField] AttackZoneScript rightAttackZone;
    Rigidbody2D rb;
    [SerializeField] int damage = 5;
    float attackRadius = 1f;
    float speed = 5;
    [SerializeField] float distance = 5f;
    [SerializeField] protected int health = 100;
    float attackTime;
    bool rightfw = true;
    protected Animator animator;
    SpriteRenderer sr;

    public int Health { get { return health; } }
    public virtual void Start()
    {
        attackTime = Time.time;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (Vector2.Distance(transform.position, Player.position) < distance)
            FollowingPlayer();
        animator.SetFloat("Velocity",Mathf.Abs(rb.velocity.x));
    }
    public virtual void FollowingPlayer()
    {
        if(Vector2.Distance(transform.position,Player.position) < attackRadius)
        {
            if (Time.time > attackTime)
            {
                rightAttackZone.EnemyAttack(damage);
                attackTime = Time.time + 0.34f;
            }
        }
        else
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            if (transform.position.x < Player.position.x)
            {
                rb.velocity = new Vector2(speed, 0);
                if (!rightfw)
                    Flip();
            }
            else
                if (transform.position.x > Player.position.x)
            {
                rb.velocity = new Vector2(-speed, 0);
                if (rightfw)
                    Flip();
            }
        }
    }
    public void Flip()
    {
        if (rightfw)
            transform.rotation = new Quaternion(0, 180, 0, 0);
        else
            transform.rotation = new Quaternion(0, 0, 0, 0);
        rightfw = !rightfw;
    }
  
    
    public virtual void GetDamage(int damage)
    {
        if (health <= 0)
            return;
        health -= damage;
        if (health <= 0)
        {
            health = 0;
            animator.SetBool("Killed", true);
            enabled = false;
            Destroy(gameObject, 0.9f);
        }
    }
    
  
}
