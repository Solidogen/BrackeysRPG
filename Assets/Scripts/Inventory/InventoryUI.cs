using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField]
    private Transform itemsParent = default;

    [SerializeField]
    private GameObject inventoryPanel = default;

    private Inventory inventory;
    private InventorySlot[] slots;

    void Start()
    {
        inventory = Inventory.Instance;
        inventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Inventory")) {
            inventoryPanel.ToggleActive();
        }
    }

    private void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
