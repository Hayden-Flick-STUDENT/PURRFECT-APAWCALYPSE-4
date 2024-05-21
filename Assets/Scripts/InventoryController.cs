using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventoryItem
{
    public GameObject itemObject;
    public int quantity;
}

public class InventoryController : MonoBehaviour
{
    public List<InventoryItem> inventory;

    void Start()
    {
        inventory = new List<InventoryItem>();
    }

    public void AddItem(GameObject itemObject, int quantity = 1)
    {
        InventoryItem item = inventory.Find(i => i.itemObject == itemObject);
        if (item != null)
        {
            item.quantity += quantity;
        }
        else
        {
            inventory.Add(new InventoryItem { itemObject = itemObject, quantity = quantity });
        }
    }

    public void RemoveItem(GameObject itemObject, int quantity = 1)
    {
        InventoryItem item = inventory.Find(i => i.itemObject == itemObject);
        if (item != null)
        {
            item.quantity -= quantity;

            if (item.quantity <= 0)
            {
                inventory.Remove(item);
            }
        }
    }

    public bool HasItem(GameObject itemObject)
    {
        return inventory.Exists(i => i.itemObject == itemObject && i.quantity > 0);
    }

    public int GetItemCount(GameObject itemObject)
    {
        InventoryItem item = inventory.Find(i => i.itemObject == itemObject);
        if (item != null)
        {
            return item.quantity;
        }

        return 0;
    }

    public void PrintInventory()
    {
        foreach (InventoryItem item in inventory)
        {
            Debug.Log(item.itemObject.name + ": " + item.quantity);
        }
    }
}
