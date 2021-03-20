using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    
    ItemInfo item;
    RawImage currentImage;
    void Start()
    {
        currentImage = GetComponentInChildren<RawImage>();
    }
    public bool IsItemPresent => item != null;
    public void SetItem(ItemInfo item)
    {
        this.item = item;
        currentImage.texture = item.itemSprite.texture;
        currentImage.color = new Color(255, 255, 255, 1);
     
    }
    public void Release()
    {
        this.item = null;
        currentImage.texture = null;
    }
}
