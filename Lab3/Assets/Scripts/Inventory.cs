using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Inventory : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]GameObject Panel;
    bool IsActive;
    public bool IsOver;
    void Start()
    {
        Panel.SetActive(false);
        IsActive= false;
        IsOver = false;
    }
    public void OnExit()
    {
        if (ItemHolder.Instance.IsSelected)
            return;
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
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.I))
            ChangeState();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        IsOver = true;  
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        IsOver = false;
    }
}
