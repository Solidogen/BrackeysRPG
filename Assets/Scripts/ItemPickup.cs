using UnityEngine;

public class ItemPickup : Interactable
{
    [SerializeField]
    private Item item = default;

    public override void Interact()
    {
        base.Interact();
        PickUp();
    }

    private void PickUp()
    {
        Debug.Log("Picking up " + item.name);
        FindObjectOfType<Inventory>().AddItem(item);
        Destroy(gameObject);
    }
}
