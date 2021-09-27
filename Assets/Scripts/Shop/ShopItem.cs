using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, IDeselectHandler
{
    public enum ShopItemStatus { CanBuy, CannotBuy, AlreadyOwned, Equiped }

    [SerializeField] private Image _image;
    [SerializeField] private Text _priceText;
    [SerializeField] private Text _equipedText;

    public ShopItemStatus ItemStatus;
    private int _price;
    private ShopManager _shop;
    private ClothesSO _item;

    private Vector2 _selectedObjectScale = new Vector2(1.2f, 1.2f);

    public void SetItemData(ClothesSO clothe, InventorySO playerInventory, ShopManager shopManager)
    {
        _image.sprite = clothe.Sprite;
        _price = clothe.Price;
        _priceText.text = _price.ToString();
        _shop = shopManager;
        _item = clothe;

        CheckItemStatus(clothe, playerInventory);
    }

    public void BuyItem(InventorySO playerInventory)
    {
        playerInventory.Coins -= _price;
        playerInventory.AdquireClothes(_item);
        UpdateItem(playerInventory);
        _shop.SelectItem(this);
        SoundManager.Instance.PlaySound(SoundManager.Instance.Sounds.CoinSound);
    }

    public void SellItem(InventorySO playerInventory)
    {
        playerInventory.Coins += _price;
        playerInventory.RemoveOwnedClothes(_item);
        playerInventory.UnequipClothes(_item);
        UpdateItem(playerInventory);
        _shop.SelectItem(this);
        SoundManager.Instance.PlaySound(SoundManager.Instance.Sounds.CoinSound);
    }

    public void EquipItem(InventorySO playerInventory)
    {
        playerInventory.Equip(_item);
        UpdateItem(playerInventory);
        _shop.SelectItem(this);

    }

    public void UpdateItem(InventorySO playerInventory)
    {
        CheckItemStatus(_item, playerInventory);
    }

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

    private void SelectItem()
    {
        SoundManager.Instance.PlaySound(SoundManager.Instance.Sounds.ClickSound);
        gameObject.GetComponentInChildren<Outline>().enabled = true;
        _shop.SelectItem(this);
    }

    private void DeselectItem()
    {
        gameObject.GetComponentInChildren<Outline>().enabled = false;
    }

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
