using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    Rigidbody2D rb;
    int d;
    [SerializeField] float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        d = 1;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {     
        rb.velocity = new Vector2(speed * d,0);
    }
 
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
    
            d *= -1;
        }
        else
            if (collision.gameObject.tag == "Player")
        {

            CapsuleCollider2D b = collision.gameObject.GetComponent<CapsuleCollider2D>();
            PhysicsMaterial2D material2D = new PhysicsMaterial2D();
            material2D.friction = 30;
            b.sharedMaterial = material2D;
        }

    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            CapsuleCollider2D b = collision.gameObject.GetComponent<CapsuleCollider2D>();
            PhysicsMaterial2D material2D = new PhysicsMaterial2D();
            material2D.friction = 0;
            b.sharedMaterial = material2D;
        }
    }




}
