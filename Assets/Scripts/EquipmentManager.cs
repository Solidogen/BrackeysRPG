using UnityEngine;

public class EquipmentManager : Singleton<EquipmentManager>
{
    [SerializeField]
    private SkinnedMeshRenderer targetMesh;

    private Equipment[] currentEquipment;
    private SkinnedMeshRenderer[] currentMeshes;
    private Inventory inventory;

    public delegate void OnEquipmentChanged(Equipment newEquipment, Equipment oldEquipment);
    public OnEquipmentChanged onEquipmentChanged;

    void Start()
    {
        inventory = Inventory.Instance;
        // todo THIS SUCKS, these should be 6 Equipment subclasses instead of array
        // or Dictionary<EquipmentSlot, Equipment> maybe?
        int equipmentTypesCount = System.Enum.GetNames(typeof(EquipmentType)).Length;
        currentEquipment = new Equipment[equipmentTypesCount];
        currentMeshes = new SkinnedMeshRenderer[equipmentTypesCount];
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            UnequipAll();
        }
    }

    public void Equip(Equipment newEquipment)
    {
        // todo THIS SUCKS, any change in enum will break whole inventory
        int slotIndex = (int)newEquipment.type;

        var oldEquipment = currentEquipment[slotIndex];
        oldEquipment?.Run(it =>
        {
            inventory.AddItem(it);
        });
        currentEquipment[slotIndex] = newEquipment;

        onEquipmentChanged?.Invoke(newEquipment: newEquipment, oldEquipment: oldEquipment);
        
        var newMesh = Instantiate<SkinnedMeshRenderer>(newEquipment.mesh);
        newMesh.transform.parent = targetMesh.transform;
        newMesh.bones = targetMesh.bones;
        newMesh.rootBone = targetMesh.rootBone;

        currentMeshes[slotIndex] = newMesh;
    }

    public void Unequip(int slotIndex)
    {
        // todo THIS SUCKS, I should be able to unequip item by it's type
        var oldEquipment = currentEquipment[slotIndex];
        oldEquipment?.Run(e =>
        {
            var oldMesh = currentMeshes[slotIndex];
            oldMesh?.Run(m => {
                Destroy(oldMesh.gameObject);
            });
            
            inventory.AddItem(oldEquipment);
            currentEquipment[slotIndex] = null;

            onEquipmentChanged?.Invoke(newEquipment: null, oldEquipment: oldEquipment);
        });
    }

    public void UnequipAll()
    {
        // todo SUCKS as everything in this class
        for (int i = 0; i < currentEquipment.Length; i++)
        {
            Unequip(i);
        }
    }
}
