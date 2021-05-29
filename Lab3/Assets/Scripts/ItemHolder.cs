using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemHolder : MonoBehaviour
{
    [SerializeField] Image itemImage;
    [SerializeField] Inventory Inventory;
    InventoryItem firstCell;
    InventoryItem secondCell;
    bool isSelected;
    public bool IsSelected => isSelected;
    static ItemHolder instance;
    public static ItemHolder Instance => instance;
    ItemInfo info;
    public ItemInfo movedItem => info;
    private void Awake()
    {
      instance = this;
    }
    void Start()
    {
        isSelected = false;
        info = null;

    }
    public void UnSelect()
    {
        if (isSelected) 
        { 
            isSelected = false;
            itemImage.sprite = null;
            itemImage.color = Color.clear;
        }
        }
    public void Choose(InventoryItem firstCell)
    {
        this.firstCell = firstCell;
        info = firstCell.itemInfo;
        firstCell.Release();
        SetMovedItemImage();
        isSelected = true;
    }
    private void Update()
    {
        if (IsSelected)
        {
            if (!Inventory.IsOver && Input.GetMouseButton(0))
            {
                Debug.Log("Drop");
                UnSelect();
            }
            else
                if (Input.GetMouseButton(1))
            {
                firstCell.SetItem(info);
                UnSelect();
            }
            else
            itemImage.transform.position = Input.mousePosition;
        }
        
    }
    void SetMovedItemImage()
    {
        itemImage.color = Color.white;
        itemImage.sprite = info.itemSprite;
    }
    public void Insert(InventoryItem secondCell)
    {
      
            this.secondCell = secondCell;
          if(firstCell.HasItem)
                firstCell.Release();
            if (secondCell.HasItem)
            {
                    ItemInfo current = info;
                    info = secondCell.itemInfo;
                    secondCell.SetItem(current);
                    SetMovedItemImage();
            }
            else
            {
                secondCell.SetItem(info);
            UnSelect();
            }
        
       
    }
}
