using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    private Item item;

    [SerializeField]
    private Image icon = default;

    [SerializeField]
    private Button itemButton = default;

    [SerializeField]
    private Button removeButton = default;

    void Start()
    {
        removeButton.onClick.AddListener(delegate
        {
            Inventory.Instance.RemoveItem(item);
        });
        itemButton.onClick.AddListener(delegate
        {
            item?.Use();
        });
    }

    public void AddItem(Item item)
    {
        this.item = item;
        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }
}
