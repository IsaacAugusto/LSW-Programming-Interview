using UnityEngine;
using System.IO;

public class ScriptableSaveSystem
{
    public static void InventorySave(InventorySO inventory)
    {
        if (File.Exists($"{Application.persistentDataPath}/SaveData/Inventory"))
        {
            var json = JsonUtility.ToJson(inventory);
            File.WriteAllText($"{Application.persistentDataPath}/SaveData/Inventory", json);
        }
        else
        {
            Directory.CreateDirectory($"{Application.persistentDataPath}/SaveData");
            var json = JsonUtility.ToJson(inventory);
            File.WriteAllText($"{Application.persistentDataPath}/SaveData/Inventory", json);
        }
    }

    public static void InventoryLoad(InventorySO inventory)
    {
        if (File.Exists($"{Application.persistentDataPath}/SaveData/Inventory"))
        {
            var json = File.ReadAllText($"{Application.persistentDataPath}/SaveData/Inventory");
            JsonUtility.FromJsonOverwrite(json, inventory);
        }
        inventory.WarmUpDefaultClothes();
    }
}
