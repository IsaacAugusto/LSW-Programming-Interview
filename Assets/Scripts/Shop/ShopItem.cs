using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public enum ShopItemStatus { CanBuy, CannotBuy, AlreadyOwned }

    public ShopItemStatus ItemStatus;
    [SerializeField] private Image _image;
    [SerializeField] private Text _priceText;
    private int _price;

    public void SetItemData(ClothesSO clothe, int playerCoins, InventorySO playerInventory)
    {
        _image.sprite = clothe.Sprite;
        _price = clothe.Price;
        _priceText.text = _price.ToString();

        CheckItemStatus(playerCoins, clothe, playerInventory);
    }

    private void CheckItemStatus(int playerCoins, ClothesSO item, InventorySO playerInventory)
    {
        if (playerInventory.OwnedClothes.Contains(item))
        {
            _priceText.gameObject.SetActive(false);
            ItemStatus = ShopItemStatus.AlreadyOwned;
        }
        else if (playerCoins < _price)
        {
            _priceText.color = Color.red;
            ItemStatus = ShopItemStatus.CannotBuy;
        }
        else
        {
            _priceText.color = Color.white;
            ItemStatus = ShopItemStatus.CanBuy;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
