using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public InventorySO Inventory;

    public List<Sprite> Torso;

    void Start()
    {
        ScriptableSaveSystem.InventoryLoad(Inventory);
    }

    public void RandomizeClothes()
    {
        int random = Random.Range(0, Torso.Count);
        Inventory.TorsoCloth = Torso[random];
        Inventory.OnValidadeAction();
    }

    public void SaveInventory()
    {
        ScriptableSaveSystem.InventorySave(Inventory);
    }

    void Update()
    {
        
    }
}
