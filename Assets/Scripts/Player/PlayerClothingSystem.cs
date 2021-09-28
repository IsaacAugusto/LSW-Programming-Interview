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

    private void Awake()
    {
        Inventory.OnValidadeAction += UpdateClothings;

    }

    private void OnDestroy()
    {
        Inventory.OnValidadeAction -= UpdateClothings;
    }


    /// <summary>
    /// Set sprites to get the clothes that are in the Inventory ScriptableObject, making visual feedback of what's equipped.
    /// </summary>
    private void UpdateClothings()
    {
        _torsoRenderer.sprite = Inventory.TorsoCloth.Sprite;

        _leftArmRenderer.sprite = Inventory.LeftArmCloth.Sprite;

        _rightArmRenderer.sprite = Inventory.RightArmCloth.Sprite;

        _leftLegRenderer.sprite = Inventory.LeftLegCloth.Sprite;

        _rightLegRenderer.sprite = Inventory.RightLegCloth.Sprite;
    }
}
