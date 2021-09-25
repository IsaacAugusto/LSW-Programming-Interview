using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClothingSystem : MonoBehaviour
{
    [Header("InventorySO")]
    public InventorySO Inventory;

    [Space]

    [Header("Renderes")]
    [SerializeField] private SpriteRenderer _torsoRenderer;
    [SerializeField] private SpriteRenderer _leftArmRenderer;
    [SerializeField] private SpriteRenderer _rightArmRenderer;
    [SerializeField] private SpriteRenderer _leftLegRenderer;
    [SerializeField] private SpriteRenderer _rightLegRenderer;

    private void Start()
    {
        Inventory.OnValidadeAction += UpdateClothings;
    }

    private void OnDestroy()
    {
        Inventory.OnValidadeAction -= UpdateClothings;
    }

    private void UpdateClothings()
    {
        _torsoRenderer.sprite = Inventory.TorsoCloth != null ?
            Inventory.TorsoCloth.Sprite : Inventory.DefaultClothes.TorsoDefault.Sprite;

        _leftArmRenderer.sprite = Inventory.LeftArmCloth != null?
            Inventory.LeftArmCloth.Sprite : Inventory.DefaultClothes.LeftArmDefault.Sprite;

        _rightArmRenderer.sprite = Inventory.RightArmCloth != null?
            Inventory.RightArmCloth.Sprite : Inventory.DefaultClothes.RightArmDefault.Sprite; 

        _leftLegRenderer.sprite = Inventory.LeftLegCloth != null?
            Inventory.LeftLegCloth.Sprite : Inventory.DefaultClothes.LeftLegDefault.Sprite;

        _rightLegRenderer.sprite = Inventory.RightLegCloth != null?
            Inventory.RightLegCloth.Sprite : Inventory.DefaultClothes.RightLegDefault.Sprite;
    }
}
