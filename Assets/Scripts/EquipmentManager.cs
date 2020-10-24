using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : Singleton<EquipmentManager>
{
    private Equipment[] currentEquipment;
    private Inventory inventory;

    void Start()
    {
        inventory = Inventory.Instance;
        // todo THIS SUCKS, these should be 6 Equipment subclasses instead of array
        int equipmentTypesCount = System.Enum.GetNames(typeof(EquipmentType)).Length;
        currentEquipment = new Equipment[equipmentTypesCount];
    }

    public void Equip(Equipment equipment)
    {
        // todo THIS SUCKS, any change in enum will break whole inventory
        int slotIndex = (int)equipment.type;

        var oldItem = currentEquipment[slotIndex];
        oldItem?.Run(it => {
            inventory.AddItem(it);
        });
        currentEquipment[slotIndex] = equipment;
    }
}
