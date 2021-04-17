using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
public class PlayerInventory : MonoBehaviour
{
    PlayerCreature player;
    InventoryItem[] inventoryItems;
    GameObject itemsPanel;
    int itemCount => inventoryItems.Where(x => x.HasItem).Count();
    public GameObject ItemPanel { set
        {
            itemsPanel = value;
            inventoryItems = itemsPanel.GetComponentsInChildren<InventoryItem>();

        } }
    int maxcapacity = 10;
    public PlayerInventory(PlayerCreature player)
    {
        this.player = player;
    }
    public bool AddItem(ItemInfo item)
    {
        if (itemCount == maxcapacity)
        {
            Debug.Log("Inventory is full");
            return false;
        }
        int i = 0;
        while (i < inventoryItems.Length && inventoryItems[i].IsItemPresent)
            i++;
        if (i != inventoryItems.Length)
            inventoryItems[i].SetItem(item);
        return true;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.LogError("Updade");
    }
}
