using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ServiceManager : MonoBehaviour
{
    public static ServiceManager instance;
    public bool isActive { get; private set; }
    public Action OnUpdate = delegate { };
    public Action OnLateUpdate = delegate { };
    public Action OnFixedUpdate = delegate { };
    public Action DestroyAction = delegate { };
    public PCInputController inputController { get; private set; }
    public void Awake()
    {
        if (instance == null)
        {
            isActive = true;
            instance = this;
        }
        else
            Destroy(gameObject);
    }
   public void InitInputController()
    {
        if (inputController == null)
            inputController = new PCInputController(this);
    }
   public void Pause()
    {
        isActive = false;
        Time.timeScale = 0;
    }
    public void Resume()
    {
        isActive = true;
        Time.timeScale = 1;
    }
    void Update()
    {

        if (!isActive)
            return;
        OnUpdate();
    }
    void LateUpdate()
    {
        if (!isActive)
            return;
        OnLateUpdate();
    }
    void FixedUpdate()
    {
        if (!isActive)
            return;
            OnFixedUpdate();
    }
    private void OnDestroy()
    {
       DestroyAction();
    }

}
