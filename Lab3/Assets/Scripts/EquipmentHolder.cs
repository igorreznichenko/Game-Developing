using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentHolder : MonoBehaviour
{
    [SerializeField] GameObject EquipmentUI;
    [SerializeField] PlayerCreature player;
    EquipmentCell[] equipments;
    static EquipmentHolder instance;
    public static EquipmentHolder Instance => instance;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        equipments = EquipmentUI.GetComponentsInChildren<EquipmentCell>();
        
    }
  
    public bool AddInInventory(ItemInfo item)
    {
        return player.inventory.AddItem(item);
    }
    public void AddEquipment(InventoryItem item)
    {
        ItemInfo info = item.itemInfo;
        int i = 0;
        EquipmentCell equipment = null;
        while (i < equipments.Length)
        {
            if (equipments[i].canHold(item.itemInfo.ItemId))
            {
                equipment = equipments[i];
                if (!equipments[i].HasItem)
                    break;
            }
            i++;
        }
        if (equipment.HasItem)
        {
            ItemInfo itemInfo = equipment.itemInfo;
            equipment.SetItem(info);
            item.SetItem(itemInfo);
        }
        else
        {
            equipment.SetItem(info);
            item.Release();
        }
    }
}
