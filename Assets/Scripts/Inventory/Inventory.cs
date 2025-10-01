using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Dictionary<string, int> inventory = new Dictionary<string, int>();
    public static Inventory Instance;
    public GameObject slotItem;
    public Transform slotContainer;

    public List<ItemInventory> inventoryList;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        RefreshUI();
    }

    public void AddItem(string nameItem, int amount)
    {
        if(inventory.ContainsKey(nameItem))
        {
            inventory[nameItem] += amount;
        }
        else
        {
            inventory.Add(nameItem, amount);
        }
        Debug.Log("Tienes:" + inventory[nameItem] + "de " + nameItem);
        RefreshUI();
    }
    public bool SubstractItem(string nameItem, int amount)
    {
        if (inventory.ContainsKey(nameItem))
        {
            if (inventory[nameItem] >= amount)
            {
                inventory[nameItem] -= amount;
                RefreshUI();
                return true;
            }
            else
            {
                Debug.Log("No tienes sufiente");
                RefreshUI();
                return false;
            }
        }
        else
        {
            Debug.Log("No tienes el objeto");
            RefreshUI();
            return false;
        }

        
    }
    public void RefreshUI()
    {
        foreach(Transform t in slotContainer)
        {
            Destroy(t.gameObject);
        }
        if (inventory.Count > 0)
        {
            foreach(var t in inventory)
            {
                GameObject slot = Instantiate(slotItem, slotContainer);
                ItemInventory item = GetItem(t.Key);
                slot.GetComponent<SlotInventory>().SetInfo(item.itemIcon, t.Value);
            }
        }
    }
    public ItemInventory GetItem(string id)
    {
        foreach (ItemInventory item in inventoryList)
        {
            if(item.id == id)
            {
                return item;
            }
        }
        return null;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddItem("Manzana", 10);
        }
        if(Input.GetKeyDown(KeyCode.A))
        {
            SubstractItem("Manzana", 15);
        }
    }
}
