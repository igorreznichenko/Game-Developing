using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractable : Interactable
{
    [SerializeField] ChatMenu chat;
    
    protected override void Interact()
    {
        base.Interact();
        chat.Init();
    }
}
