using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringBoardButtonBehaviorScript : MonoBehaviour
{
    [SerializeField]SpringBoardBehaviorScript springBoard;
    bool clicked = false;
    public bool Clicked { 
        get { return clicked; }
        set {if (value == false)
                sr.sprite = State2;
            else
                sr.sprite = State1;
            clicked = value;
             } 
    }
    [SerializeField] Sprite State1;
    [SerializeField] Sprite State2;
    SpriteRenderer sr;
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && !Clicked)
        {
            Clicked = true;
            springBoard.Spring = false;
        }
    }
}
