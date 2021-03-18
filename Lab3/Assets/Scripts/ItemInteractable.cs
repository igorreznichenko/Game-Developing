using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteractable : Interactable
{
    [SerializeField]Item item;

    protected override void Interact()
    {
        base.Interact();
        item.Destroy(player);
    }
}
