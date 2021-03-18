using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LivingCreatureActionController
{
    [SerializeField] LivingCreature livingCreature;
    ActionType currentAction;
    // Start is called before the first frame update
   
    public LivingCreatureActionController(LivingCreature livingCreature)
    {
       this.livingCreature = livingCreature;
        livingCreature.serviceManager.DestroyAction += OnDestroy;
        livingCreature.serviceManager.OnUpdate += OnUpdate;

    }
   protected virtual void Move(Vector3 destination, float stoppingDistance = 0.6f)
    {
        livingCreature.navMesh.destination = destination;
        livingCreature.navMesh.stoppingDistance = stoppingDistance;
        SetAction(ActionType.Run);
    }
    public virtual void SetAction(ActionType actionType)
    {
        currentAction = actionType;
        if (currentAction != ActionType.Idle)
        {
            if(actionType == ActionType.Attack)
                livingCreature.animator.SetTrigger(currentAction.ToString());
            else
            livingCreature.animator.SetBool(currentAction.ToString(), true);
        }
    }
    protected virtual void ResetAction()
    {
        if(currentAction != ActionType.Idle)
            livingCreature.animator.SetBool(currentAction.ToString(), false);
        currentAction = ActionType.Idle;
        
    }
    // Update is called once per frame
    protected virtual void OnUpdate()
    {
        if (Vector3.Distance(livingCreature.transform.position, livingCreature.navMesh.destination) <= livingCreature.navMesh.stoppingDistance)
        {
            ResetAction();
            livingCreature.navMesh.destination = livingCreature.transform.position;

        }
        
    }
    protected virtual void OnDestroy()
    {

        livingCreature.serviceManager.DestroyAction -= OnDestroy;
        livingCreature.serviceManager.OnUpdate -= OnUpdate;

    }
     public enum ActionType
    {
        Run,
        Idle,
        Attack
    }
}
