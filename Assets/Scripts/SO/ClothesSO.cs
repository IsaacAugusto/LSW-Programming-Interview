using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "Clothes")]
public class ClothesSO : ScriptableObject
{
    public enum ClothesType {Torso, LeftArm, RightArm, LeftLeg, RightLeg}

    public ClothesType Type;
    public Sprite Sprite;
}
