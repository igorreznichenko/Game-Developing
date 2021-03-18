using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActionController : LivingCreatureActionController
{
    // Start is called before the first frame update
    PlayerCreature playerCreature;
    Interactable lastInteract;
    public PlayerActionController(PlayerCreature playerCreature) : base(playerCreature)
    {
        this.playerCreature = playerCreature;
        playerCreature.serviceManager.inputController.SetTarget += SetTarget;

    }
    public void SetTarget(Vector3 position, Collider collider)
    {
        if (lastInteract != null)
            lastInteract.OnUnFocuse();
        if (collider != null)
        {
           
            lastInteract = collider.GetComponent<Interactable>();
            if (lastInteract != null)
            {
                lastInteract.OnFocuse(playerCreature);
                Vector3 center = new Vector3(lastInteract.transform.position.x, playerCreature.transform.position.y, lastInteract.transform.position.z);
                Move(center, lastInteract.StoppingDistance);
                return;
            }
        }
        Move(position);
    }
    protected override void OnDestroy()
    {
        base.OnDestroy();
        playerCreature.serviceManager.inputController.SetTarget -= SetTarget;
    }
  
}
