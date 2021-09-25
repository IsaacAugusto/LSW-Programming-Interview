using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "DefaultClothes")]
public class DefaultClothesSO : ScriptableObject
{
    [Header("Default Clothes")]
    public ClothesSO TorsoDefault;
    public ClothesSO LeftArmDefault;
    public ClothesSO RightArmDefault;
    public ClothesSO LeftLegDefault;
    public ClothesSO RightLegDefault;
}
