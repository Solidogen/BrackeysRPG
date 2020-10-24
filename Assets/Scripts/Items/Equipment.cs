using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{
    [SerializeField]
    private int armorModifier = default;

    [SerializeField]
    private int damageModifier = default;

    public EquipmentType type = default;

    public override void Use()
    {
        base.Use();
        EquipmentManager.Instance.Equip(this);
        RemoveFromInventory();
    }
}
