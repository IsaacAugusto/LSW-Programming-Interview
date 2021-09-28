using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, IDeselectHandler
{
    //Enum that hold the possible states of an item in shop.
    public enum ShopItemStatus { CanBuy, CannotBuy, AlreadyOwned, Equiped }

    [SerializeField] private Image _image;
    [SerializeField] private Text _priceText;
    [SerializeField] private Text _equipedText;

    public ShopItemStatus ItemStatus;
    private int _price;
    private ShopManager _shop;
    private ClothesSO _item;

    //Scale to grow the button when hovered by mouse.
    private Vector2 _selectedObjectScale = new Vector2(1.2f, 1.2f);

    /// <summary>
    /// Function to feed the data that ShopItem needs.
    /// </summary>
    public void SetItemData(ClothesSO cloth, InventorySO playerInventory, ShopManager shopManager)
    {
        _image.sprite = cloth.Sprite;
        _price = cloth.Price;
        _priceText.text = _price.ToString();
        _shop = shopManager;
        _item = cloth;

        CheckItemStatus(cloth, playerInventory);
    }

    /// <summary>
    /// Remove the price of the item from the player coins, add item to inventory and updates visual on shop.
    /// </summary>
    public void BuyItem(InventorySO playerInventory)
    {
        playerInventory.Coins -= _price;
        playerInventory.AdquireClothes(_item);
        UpdateItem(playerInventory);
        _shop.SelectItem(this);
        SoundManager.Instance.PlaySound(SoundManager.Instance.Sounds.CoinSound);
    }

    /// <summary>
    /// Add the price of the item to the player coins, check if is equipped and remove item from inventory and updates visual on shop.
    /// </summary>
    public void SellItem(InventorySO playerInventory)
    {
        playerInventory.Coins += _price;
        playerInventory.RemoveOwnedClothes(_item);
        playerInventory.UnequipClothes(_item);
        UpdateItem(playerInventory);
        _shop.SelectItem(this);
        SoundManager.Instance.PlaySound(SoundManager.Instance.Sounds.CoinSound);
    }

    /// <summary>
    /// Equip item on the player inventory.
    /// </summary>
    public void EquipItem(InventorySO playerInventory)
    {
        playerInventory.Equip(_item);
        UpdateItem(playerInventory);
        _shop.SelectItem(this);

    }

    /// <summary>
    /// Updates the item on shop.
    /// </summary>
    public void UpdateItem(InventorySO playerInventory)
    {
        CheckItemStatus(_item, playerInventory);
    }

    /// <summary>
    /// Check and updates the item status and updates the visuals of it on shop.
    /// </summary>
    private void CheckItemStatus(ClothesSO item, InventorySO playerInventory)
    {
        if (playerInventory.CheckEquiped(item))
        {
            ItemStatus = ShopItemStatus.Equiped;
        }
        else if (playerInventory.OwnedClothes.Contains(item))
        {
            ItemStatus = ShopItemStatus.AlreadyOwned;
        }
        else if (playerInventory.Coins < _price)
        {
            ItemStatus = ShopItemStatus.CannotBuy;
        }
        else
        {
            ItemStatus = ShopItemStatus.CanBuy;
        }

        _priceText.color = ItemStatus == ShopItemStatus.CanBuy ? Color.black : _priceText.color = Color.red; ;
        _priceText.gameObject.SetActive(ItemStatus != ShopItemStatus.AlreadyOwned && ItemStatus != ShopItemStatus.Equiped);
        _equipedText.gameObject.SetActive(ItemStatus == ShopItemStatus.Equiped);
    }

    /// <summary>
    /// Set item as selected when is clicked on shop.
    /// </summary>
    private void SelectItem()
    {
        SoundManager.Instance.PlaySound(SoundManager.Instance.Sounds.ClickSound);
        gameObject.GetComponentInChildren<Outline>().enabled = true;
        _shop.SelectItem(this);
    }

    /// <summary>
    /// Remove selection from the item.
    /// </summary>
    private void DeselectItem()
    {
        gameObject.GetComponentInChildren<Outline>().enabled = false;
    }

    /// <summary>
    /// Detects when the mouse enters the item area to animate and play soundclips;
    /// </summary>
    public void OnPointerEnter(PointerEventData eventData)
    {
        LeanTween.cancel(gameObject);
        LeanTween.scale(gameObject, _selectedObjectScale, .2f);
        SoundManager.Instance.PlaySound(SoundManager.Instance.Sounds.HoverButtonSound);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        LeanTween.cancel(gameObject);
        LeanTween.scale(gameObject, Vector2.one, .1f);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        SelectItem();
        EventSystem.current.SetSelectedGameObject(gameObject);
    }

    public void OnDeselect(BaseEventData eventData)
    {
        DeselectItem();
    }
}
