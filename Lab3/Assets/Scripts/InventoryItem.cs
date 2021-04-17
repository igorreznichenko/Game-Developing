using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryItem : MonoBehaviour, IPointerClickHandler
{
    
    protected ItemInfo item;
    public ItemInfo itemInfo => item;
    protected RawImage currentImage;
    protected ItemHolder itemHolder;
    protected EquipmentHolder equipmentHolder;
    protected bool hasItem;
    public bool HasItem => hasItem;
    protected virtual void Start()
    {
        currentImage = GetComponentInChildren<RawImage>();
        hasItem = false;
        itemHolder = ItemHolder.Instance;
        equipmentHolder = EquipmentHolder.Instance;
    }
    public bool IsItemPresent => item != null;
    public virtual void SetItem(ItemInfo item)
    {
        this.item = item;
        currentImage.texture = item.itemSprite.texture;
        currentImage.color = new Color(255, 255, 255, 1);
        hasItem = true;
     
    }
    public virtual void Release()
    {
        this.item = null;
        currentImage.texture = null;
        currentImage.color = new Color(0, 0, 0, 0);
        hasItem = false;
    }
    protected virtual void OnLeftClick() {
        if (!itemHolder.IsSelected && !hasItem)
            return;
        if (!itemHolder.IsSelected)
        {
            itemHolder.Choose(this);
        }
        else
            itemHolder.Insert(this);

    }
    protected virtual void OnRightClick() {
        if (itemHolder.IsSelected)
            itemHolder.UnSelect();
        else
        if (hasItem)
        {
            equipmentHolder.AddEquipment(this);
        }
    }

    public virtual void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
            OnLeftClick();
        else
            if (eventData.button == PointerEventData.InputButton.Right)
            OnRightClick();
    }
}
