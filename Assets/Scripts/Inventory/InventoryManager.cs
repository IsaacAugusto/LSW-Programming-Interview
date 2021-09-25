using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public InventorySO Inventory;

    void Start()
    {
        LoadInventory();
    }

    private void OnApplicationQuit()
    {
        SaveInventory();
    }

    public void SaveInventory()
    {
        ScriptableSaveSystem.InventorySave(Inventory);
    }

    public void LoadInventory()
    {
        ScriptableSaveSystem.InventoryLoad(Inventory);
        Inventory.OnValidadeAction?.Invoke();
    }

    public void EquipRandomClothes()
    {
        List<ClothesSO> ownedPieces;
        int random;
        foreach (int typeNumber in Enum.GetValues(typeof(ClothesSO.ClothesType)))
        {
            ownedPieces = Inventory.OwnedClothes.FindAll((clothe) => clothe.Type == (ClothesSO.ClothesType)typeNumber);
            random = UnityEngine.Random.Range(0, ownedPieces.Count);
            EquipClothes(ownedPieces[random]);
        }
    }

    public void EquipClothes(ClothesSO clothes)
    {
        Inventory.Equip(clothes);
    }
}
