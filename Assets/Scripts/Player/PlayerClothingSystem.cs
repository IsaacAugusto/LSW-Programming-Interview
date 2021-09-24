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
        UpdateClothings();
    }

    private void OnDestroy()
    {
        Inventory.OnValidadeAction -= UpdateClothings;
    }

    private void UpdateClothings()
    {
        _torsoRenderer.sprite = Inventory.TorsoCloth;
        _leftArmRenderer.sprite = Inventory.LeftArmCloth;
        _rightArmRenderer.sprite = Inventory.RightArmCloth;
        _leftLegRenderer.sprite = Inventory.LeftLegCloth;
        _rightLegRenderer.sprite = Inventory.RightLegCloth;
    }
}
