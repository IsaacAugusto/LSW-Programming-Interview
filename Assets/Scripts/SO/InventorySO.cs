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

    public void AddCoins(int amount)
    {
        if (Coins + amount <= 1000)
        {
            Coins += amount;
        }
        else
        {
            Coins = 1000;
        }
        SoundManager.Instance.PlaySound(SoundManager.Instance.Sounds.CoinSound);
    }

    public void ReduceCoins(int amount)
    {
        if (Coins - amount >= 0)
        {
            Coins -= amount;
        }
        else
        {
            Coins = 0;
        }
        SoundManager.Instance.PlaySound(SoundManager.Instance.Sounds.CoinSound);
    }

    public bool CheckEquiped(ClothesSO item)
    {
        return (RightLegCloth == item) || (LeftLegCloth == item)
            || (RightArmCloth == item) || (LeftArmCloth == item)
            || (TorsoCloth == item);
    }

    public void UnequipClothes(ClothesSO item)
    {
        switch (item.Type)
        {
            case ClothesSO.ClothesType.Torso:
                if (TorsoCloth.Equals(item))
                    Equip(DefaultClothes.TorsoDefault);
                break;
            case ClothesSO.ClothesType.LeftArm:
                if (LeftArmCloth.Equals(item))
                    Equip(DefaultClothes.LeftArmDefault);
                break;
            case ClothesSO.ClothesType.RightArm:
                if (RightArmCloth.Equals(item))
                    Equip(DefaultClothes.RightArmDefault);
                break;
            case ClothesSO.ClothesType.LeftLeg:
                if (LeftLegCloth.Equals(item))
                    Equip(DefaultClothes.LeftLegDefault);
                break;
            case ClothesSO.ClothesType.RightLeg:
                if (RightLegCloth.Equals(item))
                    Equip(DefaultClothes.RightLegDefault);
                break;
            default:
                break;
        }
    }

    public void RemoveOwnedClothes(ClothesSO item)
    {
        if (OwnedClothes.Contains(item))
        {
            OwnedClothes.Remove(item);
        }
    }

    public void AdquireClothes(ClothesSO item)
    {
        if (!OwnedClothes.Contains(item))
        {
            OwnedClothes.Add(item);
        }
    }

    public void WarmUpDefaultClothes()
    {
        DefaultClothes = Resources.Load<DefaultClothesSO>("DefaultClothes");

        if (!OwnedClothes.Contains(DefaultClothes.TorsoDefault)) { OwnedClothes.Add(DefaultClothes.TorsoDefault); }
        if (!OwnedClothes.Contains(DefaultClothes.LeftArmDefault)) { OwnedClothes.Add(DefaultClothes.LeftArmDefault); }
        if (!OwnedClothes.Contains(DefaultClothes.RightArmDefault)) { OwnedClothes.Add(DefaultClothes.RightArmDefault); }
        if (!OwnedClothes.Contains(DefaultClothes.LeftLegDefault)) { OwnedClothes.Add(DefaultClothes.LeftLegDefault); }
        if (!OwnedClothes.Contains(DefaultClothes.RightLegDefault)) { OwnedClothes.Add(DefaultClothes.RightLegDefault); }

        if (TorsoCloth == null) { TorsoCloth = DefaultClothes.TorsoDefault; }
        if(LeftArmCloth == null) { LeftArmCloth = DefaultClothes.LeftArmDefault; }
        if (RightArmCloth == null) { RightArmCloth = DefaultClothes.RightArmDefault; }
        if (LeftLegCloth == null) { LeftLegCloth = DefaultClothes.LeftLegDefault; }
        if (RightLegCloth == null) { RightLegCloth = DefaultClothes.RightLegDefault; }

        OwnedClothes.RemoveAll((x) => x == null);
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
        SoundManager.Instance.PlaySound(SoundManager.Instance.Sounds.EquipSound);
        OnValidadeAction?.Invoke();
    }
}
