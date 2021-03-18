using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Interactable : MonoBehaviour
{
    bool isFocused;
    bool hasInteracted;
    protected PlayerCreature player;
    [SerializeField] float interactionDistance;
    public float StoppingDistance { get { return interactionDistance * 0.9f; } }
    public void OnFocuse(PlayerCreature player)
    {
        isFocused = true;
        this.player = player;
    }
    public void OnUnFocuse()
    {
        isFocused = false;
        hasInteracted = false;
    }

    void Update()
    {
        if (isFocused && player != null)
        {
            Vector3 center = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
            if (Vector3.Distance(center, player.transform.position) < interactionDistance && !hasInteracted)
            {
                Interact();
            }
        }
    }
     protected virtual void Interact()
    {
        hasInteracted = true;
        Debug.Log("Interact with" + gameObject);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, interactionDistance);
    }
}
