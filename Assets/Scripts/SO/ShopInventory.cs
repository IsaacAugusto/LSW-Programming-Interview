using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ShopInventory")]
public class ShopInventory : ScriptableObject
{
    public List<ClothesSO> Items;

    public List<ClothesSO> GetAllItems()
    {
        return Items;
    }

    public List<ClothesSO> GetItemsFilter(ClothesSO.ClothesType typeFilter)
    {
        return Items.FindAll((clothe) => clothe.Type == typeFilter);
    }
}
