using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "Inventory")]
public class InventorySO : ScriptableObject
{
    public int Coins;

    [Space]
    [Header("Equiped Clothes")]
    public ClothesSO TorsoCloth;
    public ClothesSO LeftArmCloth;
    public ClothesSO RightArmCloth;
    public ClothesSO LeftLegCloth;
    public ClothesSO RightLegCloth;

    [Space]
    [Header("Default Clothes")]
    public DefaultClothesSO DefaultClothes;

    [Space]
    [Header("Owned Clothes")]
    public List<ClothesSO> OwnedClothes;

    [Header("OnValidadeEvent")]
    public Action OnValidadeAction;

    private void OnValidate()
    {
        OnValidadeAction?.Invoke();
    }

    public void WarmUpDefaultClothes()
    {
        DefaultClothes = Resources.Load<DefaultClothesSO>("DefaultClothes");

        if (!OwnedClothes.Contains(DefaultClothes.TorsoDefault)) { OwnedClothes.Add(DefaultClothes.TorsoDefault); }
        if (!OwnedClothes.Contains(DefaultClothes.LeftArmDefault)) { OwnedClothes.Add(DefaultClothes.LeftArmDefault); }
        if (!OwnedClothes.Contains(DefaultClothes.RightArmDefault)) { OwnedClothes.Add(DefaultClothes.RightArmDefault); }
        if (!OwnedClothes.Contains(DefaultClothes.LeftLegDefault)) { OwnedClothes.Add(DefaultClothes.LeftLegDefault); }
        if (!OwnedClothes.Contains(DefaultClothes.RightLegDefault)) { OwnedClothes.Add(DefaultClothes.RightLegDefault); }
    }

    public void Equip(ClothesSO clothes)
    {
        switch (clothes.Type)
        {
            case ClothesSO.ClothesType.Torso:
                TorsoCloth = clothes;
                break;
            case ClothesSO.ClothesType.LeftArm:
                LeftArmCloth = clothes;
                break;
            case ClothesSO.ClothesType.RightArm:
                RightArmCloth = clothes;
                break;
            case ClothesSO.ClothesType.LeftLeg:
                LeftLegCloth = clothes;
                break;
            case ClothesSO.ClothesType.RightLeg:
                RightLegCloth = clothes;
                break;
            default:
                break;
        }
        OnValidadeAction?.Invoke();
    }
}
