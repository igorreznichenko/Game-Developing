using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerInventory : MonoBehaviour
{
    PlayerCreature player;
    List<ItemInfo> inventoryItems = new List<ItemInfo>();
    GameObject itemsPanel;
    public GameObject ItemPanel { set
        {
            itemsPanel = value;
        } }
    int maxcapacity = 10;
    public PlayerInventory(PlayerCreature player)
    {
        this.player = player;
    }
    public bool AddItem(ItemInfo item)
    {
        if (inventoryItems.Count == maxcapacity)
        {
            Debug.Log("Inventory is full");
            return false;
        }
        InventoryItem[] items = itemsPanel.GetComponentsInChildren<InventoryItem>();
        int i = 0;
        while (i < items.Length && items[i].IsItemPresent)
            i++;
        if (i != items.Length)
            items[i].SetItem(item);

        inventoryItems.Add(item);
        return true;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.LogError("Updade");
    }
}
