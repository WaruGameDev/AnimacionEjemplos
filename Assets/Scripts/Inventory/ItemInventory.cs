using UnityEngine;

[CreateAssetMenu(fileName = "ItemInventory", menuName = "Inventory/Item")]
public class ItemInventory : ScriptableObject
{
    public string id;
    public string itemName;
    public Sprite itemIcon;
    public GameObject itemGameObject;
}
