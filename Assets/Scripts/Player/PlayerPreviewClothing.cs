using UnityEngine;
using UnityEngine.UI;

public class PlayerPreviewClothing : MonoBehaviour
{
    [Header("InventorySO")]
    public InventorySO Inventory;

    [Space]

    [Header("Renderes")]
    [SerializeField] private Image _torsoRenderer;
    [SerializeField] private Image _leftArmRenderer;
    [SerializeField] private Image _rightArmRenderer;
    [SerializeField] private Image _leftLegRenderer;
    [SerializeField] private Image _rightLegRenderer;

    private void Awake()
    {
        Inventory.OnValidadeAction += UpdateClothings;
    }

    private void OnEnable()
    {
        UpdateClothings();
    }

    private void OnDestroy()
    {
        Inventory.OnValidadeAction -= UpdateClothings;
    }

    private void UpdateClothings()
    {
        _torsoRenderer.sprite = Inventory.TorsoCloth != null ?
            Inventory.TorsoCloth.Sprite : Inventory.DefaultClothes.TorsoDefault.Sprite;

        _leftArmRenderer.sprite = Inventory.LeftArmCloth != null ?
            Inventory.LeftArmCloth.Sprite : Inventory.DefaultClothes.LeftArmDefault.Sprite;

        _rightArmRenderer.sprite = Inventory.RightArmCloth != null ?
            Inventory.RightArmCloth.Sprite : Inventory.DefaultClothes.RightArmDefault.Sprite;

        _leftLegRenderer.sprite = Inventory.LeftLegCloth != null ?
            Inventory.LeftLegCloth.Sprite : Inventory.DefaultClothes.LeftLegDefault.Sprite;

        _rightLegRenderer.sprite = Inventory.RightLegCloth != null ?
            Inventory.RightLegCloth.Sprite : Inventory.DefaultClothes.RightLegDefault.Sprite;
    }
}
