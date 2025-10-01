using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlotInventory : MonoBehaviour
{
    public TextMeshProUGUI quantityText;
    public Image iconItem;

    public void SetInfo(Sprite itemSprite, int quantity)
    {
        iconItem.sprite = itemSprite;
        quantityText.text = "x"+ quantity;
    }
    
}
