using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public ItemInventory itemProfile;

    private void Start()
    {
        foreach(Transform t in transform)
        {
            Destroy(t.gameObject);
        }
        Instantiate(itemProfile.itemGameObject, transform);
    }
    private void OnMouseDown()
    {
        Inventory.Instance.AddItem(itemProfile.id, 1);
        Destroy(gameObject);
    }

}
