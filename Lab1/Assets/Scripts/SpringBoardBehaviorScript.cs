using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringBoardBehaviorScript : MonoBehaviour
{

    [SerializeField] SpringBoardButtonBehaviorScript button;
    bool spring = true;
    public bool Spring
    {
        get { return spring; }
        set
        {
            if (value == false)
                sr.sprite = State1;
            else
                sr.sprite = State2;
            spring = value;
        }
    }
    [SerializeField] int Force;
    [SerializeField] Sprite State1;
    [SerializeField] Sprite State2;
    SpriteRenderer sr;
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && !spring)
        {
            Rigidbody2D rigidbody = collision.GetComponent<Rigidbody2D>();
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, Force);
            button.Clicked = false;
            Spring = true;
        }
    }
}
