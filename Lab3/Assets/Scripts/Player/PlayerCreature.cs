using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCreature : LivingCreature
{
    // Start is called before the first frame update
    public PCInputController inputController { get; private set; }
    
    public PlayerInventory inventory { get; private set; }
    protected override void Start()
    {
        base.Start();
        actionController = new PlayerActionController(this);
        inventory = new PlayerInventory(this);
    }

   
}
