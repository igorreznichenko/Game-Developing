using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropedPlatformBehaviorScript : MonoBehaviour
{

    bool activated = false;
    [SerializeField] float seconds;
    Rigidbody2D rb;
    float x, y;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        x = transform.position.x;
        y = transform.position.y;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && !activated)
        {
            activated = true;
            StartCoroutine(DropPlatform());
        }
        
    }
    public void SetPosition()
    {
        rb.velocity = new Vector2(0, 0);
        transform.position = new Vector2(x, y);
        activated = false;
        rb.isKinematic = true;
    }
    IEnumerator DropPlatform()
    {
        yield return new WaitForSeconds(seconds);
        rb.isKinematic = false;
        
    }
   
}
