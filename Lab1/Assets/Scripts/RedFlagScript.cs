using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedFlagScript : MonoBehaviour
{
    [SerializeField] Animator GreenFlag;
    Animator animator;
    int isReached;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            animator.SetBool("IsReached", true);
        }
    }
}
