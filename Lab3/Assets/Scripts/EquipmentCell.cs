using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EquipmentCell : InventoryItem, IPointerEnterHandler, IPointerExitHandler
{
    Texture defaultTexture;
    [SerializeField] ItemId[] items;
    protected override void Start()
    {
        base.Start();
        currentImage = GetComponentInChildren<RawImage>();
        defaultTexture = currentImage.texture;
    }
    public bool canHold(ItemId item)
    {
        return items.Contains(item);
    }
    public override void SetItem(ItemInfo item)
    {
        base.SetItem(item);
    }
    public override void Release()
    {
        currentImage.texture = defaultTexture;
        currentImage.color = Color.white;
        hasItem = false;
    }
    protected override void OnLeftClick()
    {
        if((itemHolder.IsSelected && canHold(itemHolder.movedItem.ItemId)) || !itemHolder.IsSelected)
        base.OnLeftClick();
    }
    protected override void OnRightClick()
    {
        if (hasItem && EquipmentHolder.Instance.AddInInventory(item))
            Release();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (itemHolder.IsSelected && !canHold(itemHolder.movedItem.ItemId))
            currentImage.color = Color.red;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (currentImage.color == Color.red)
            currentImage.color = Color.white;
    }
}
