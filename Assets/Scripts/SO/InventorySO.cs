using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory")]
public class InventorySO : ScriptableObject
{
    public int Coins;
    [Space]
    public Sprite TorsoCloth;
    public Sprite LeftArmCloth;
    public Sprite RightArmCloth;
    public Sprite LeftLegCloth;
    public Sprite RightLegCloth;

    [Header("OnValidadeEvent")]
    public Action OnValidadeAction;

    private void OnValidate()
    {
        OnValidadeAction?.Invoke();
    }
}
