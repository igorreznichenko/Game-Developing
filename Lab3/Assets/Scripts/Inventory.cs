using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]GameObject Panel;
    bool IsActive;
    void Start()
    {
        Panel.SetActive(false);
        IsActive= false;
    }
    public void OnExit()
    {
        ChangeState();

    }
    void ChangeState()
    {
        IsActive = !IsActive;
        Panel.SetActive(IsActive);
        if (IsActive)
            ServiceManager.instance.Pause();
        else
            ServiceManager.instance.Resume();
    }
    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.I))
            ChangeState();
    }
}
