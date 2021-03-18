using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    PlayerCreature player;
    List<ItemInfo> inventoryItems = new List<ItemInfo>();
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
        inventoryItems.Add(item);
        ShowInventory();
        return true;
    }
    void ShowInventory()
    {
        foreach (var item in inventoryItems)
            Debug.Log(item.ItemId);

        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
