using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, IDeselectHandler
{
    public enum ShopItemStatus { CanBuy, CannotBuy, AlreadyOwned }

    [SerializeField] private Image _image;
    [SerializeField] private Text _priceText;

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
    }

    public void SellItem(InventorySO playerInventory)
    {
        playerInventory.Coins += _price;
        playerInventory.RemoveClothers(_item);
        UpdateItem(playerInventory);
        _shop.SelectItem(this);
    }

    public void EquipItem(InventorySO playerInventory)
    {
        playerInventory.Equip(_item);
    }

    public void UpdateItem(InventorySO playerInventory)
    {
        CheckItemStatus(_item, playerInventory);
    }

    private void CheckItemStatus(ClothesSO item, InventorySO playerInventory)
    {
        if (playerInventory.OwnedClothes.Contains(item))
        {
            _priceText.gameObject.SetActive(false);
            ItemStatus = ShopItemStatus.AlreadyOwned;
        }
        else if (playerInventory.Coins < _price)
        {
            _priceText.gameObject.SetActive(true);
            _priceText.color = Color.red;
            ItemStatus = ShopItemStatus.CannotBuy;
        }
        else
        {
            _priceText.gameObject.SetActive(true);
            _priceText.color = Color.white;
            ItemStatus = ShopItemStatus.CanBuy;
        }
    }

    private void SelectItem()
    {
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
