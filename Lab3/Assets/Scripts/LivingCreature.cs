using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody), typeof(Collider), typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public abstract class LivingCreature : MonoBehaviour
{
    public Rigidbody rigidbody { get; private set; }
    public Collider collider { get; private set; }
    public NavMeshAgent navMesh { get; private set; }
    public Animator animator { get; private set; }

    protected LivingCreatureActionController actionController;
    public LivingCreatureActionController ActionController { get { return actionController; } }
    public ServiceManager serviceManager { get; private set; }
    // Start is called before the first frame update
    protected virtual void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
        navMesh = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        serviceManager = ServiceManager.instance;
        serviceManager.InitInputController();
    }

 
}
