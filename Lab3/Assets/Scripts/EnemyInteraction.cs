using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInteraction : Interactable
{
    protected override void Interact()
    {
        base.Interact();
        player.ActionController.SetAction(LivingCreatureActionController.ActionType.Attack);
        //getDamage

    }
}
