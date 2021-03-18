using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PCInputController
{
    bool leftPointerClicked;
    public Action<Vector3, Collider> SetTarget = delegate { };
    Camera mainCamera;
    ServiceManager serviceManager;
    // Start is called before the first frame update
    public PCInputController(ServiceManager serviceManager)
    {
        mainCamera = Camera.main;
        this.serviceManager = serviceManager;
        serviceManager.OnUpdate += OnUpdate;
        serviceManager.OnFixedUpdate += OnFixedUpdate;
        serviceManager.DestroyAction += OnDestroy;
        
    }

    // Update is called once per frame
    void OnUpdate()
    {
        leftPointerClicked = Input.GetButton("Fire1");
    }
    private void OnFixedUpdate()
    {
      
        if (leftPointerClicked)
        {
            RaycastHit raycast;
            if (Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out raycast, 100))
            {
                SetTarget(raycast.point, raycast.collider);
            }
        }

    }
    private void OnDestroy()
    {
        serviceManager.OnUpdate -= OnUpdate;
        serviceManager.OnFixedUpdate -= OnFixedUpdate;
        
    }
}
 