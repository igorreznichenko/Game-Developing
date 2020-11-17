using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField] GameObject respawn;
    [SerializeField] AttackZoneScript RightAttackZone;
    [SerializeField] LevelManagerScript LevelManager;
    AttackZoneScript currentAttackZone;
    Rigidbody2D rb;
    CapsuleCollider2D bc;
    SpriteRenderer sr;
    Animator animator;
   
    bool CanJump;
    bool CanDoubleJump;
    float speed = 10;
    float JumpForce = 30;
    int health;
    int healthAmount;
    [SerializeField] int damage = 20;
    [SerializeField] int blockDamage = 5;
    int score;
    float TimeAttack;
    bool rightfw = true;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        bc = GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>();
        health = 100;
        currentAttackZone = RightAttackZone;
        healthAmount = 3;
        LevelManager.SetHealthAmount = healthAmount;
        score = 0;
    }
    public int Score { get { return score; } }
    public int Health { get { return health; } }
    public void AddLife()
    {

        LevelManager.SetHealthAmount = ++healthAmount;
    }
    void Update()
    {
        CanJump = bc.IsTouchingLayers();
        if (Input.GetKey(KeyCode.B) && Time.time > TimeAttack)
        {
            currentAttackZone.PlayerAttack(blockDamage,AttackZoneScript.PlayerAttackType.shield);
            TimeAttack = Time.time + 0.34f;
        }
        if (Input.GetKey(KeyCode.Z) && Time.time > TimeAttack)
        {
            currentAttackZone.PlayerAttack(damage,AttackZoneScript.PlayerAttackType.sword);
            TimeAttack = Time.time + 0.34f;
        }
        else
        {
            
            float s = Input.GetAxis("Horizontal");
            if (s > 0 && rightfw == false)
                Flip();
            else
                if (s < 0 && rightfw == true)
                Flip();
            rb.velocity = new Vector2(s * speed, rb.velocity.y);
        }
        if (Input.GetKeyDown(KeyCode.Space) && CanJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
            CanDoubleJump = true;
        }
        else
        if (Input.GetKeyDown(KeyCode.Space) && CanDoubleJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
            CanDoubleJump = false;
        }

        
        animator.SetFloat("Speed", Math.Abs(rb.velocity.x));
        animator.SetBool("CanJump", CanJump);


    }
    public void Flip()
    {
        if (rightfw)
        transform.rotation = new Quaternion(0, 180, 0, 0);
        else
            transform.rotation = new Quaternion(0, 0, 0, 0);
        rightfw = !rightfw;
    }
    public void AddScore(int score)
    {
        this.score += score;
        LevelManager.SetScore(this.score);
    }
    public void GetDamage(int damage)
    {
        if(health > 0 && (!animator.GetCurrentAnimatorStateInfo(0).IsName("PlayerBlock") || damage == 100))
            StartCoroutine(getDamage(damage));
    }
    private IEnumerator getDamage(int damage)
    {
        
            health -= damage;
        if (health <= 0)
        {
            enabled = false;
            animator.SetTrigger("Killed");
            health = 0;
            LevelManager.ChangeHealth(health);
            yield return new WaitForSeconds(0.82f);

            if (healthAmount > 1)
            {
                transform.position = respawn.transform.position;
                LevelManager.SetHealthAmount = --healthAmount;
                health = 100;
                LevelManager.ChangeHealth(health);
                rb.velocity = new Vector2(0, 0);
                enabled = true;
            }
            else
            {
                LevelManager.SetActiveGameOverMenu();
                gameObject.SetActive(false);
            }

        }
        else
            LevelManager.ChangeHealth(health);
            
        
    }
    public void AddHealth(int amount)
    {
        health += amount;
        if (health > 100)
            health = 100;
        LevelManager.ChangeHealth(health);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
      
            if (collision.CompareTag("RedFlag"))
            {
            respawn.transform.position = new Vector3(collision.transform.position.x, collision.transform.position.y + 2, respawn.transform.position.z);
            collision.tag = "GreenFlag";
            }
     

    }
    
    public void ChangeSpeed(int BonusSpeed, float duration)
    {
        StartCoroutine(changeSpeed(BonusSpeed, duration));
    }
    IEnumerator changeSpeed(int BonusSpeed, float duration)
    {
        speed += BonusSpeed;
        LevelManager.SetActiveSpeedBonus(true);
        yield return new WaitForSecondsRealtime(duration);
        LevelManager.SetActiveSpeedBonus(false);
        speed -= BonusSpeed;
    }
}
