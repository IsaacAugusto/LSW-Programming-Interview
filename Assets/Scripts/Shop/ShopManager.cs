using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public ShopInventory ShopGoods;
    public InventorySO PlayerInventory;

    private ShopKeeper _shopKeeper;

    [SerializeField] private Text _playerCoinsText;
    [SerializeField] private RectTransform _itemsHolder;
    [SerializeField] private RectTransform _containerHolder;
    [SerializeField] private GameObject _itemPrefab;

    [Space]
    [Header("Buttons")]
    [SerializeField] private Button _buyButton;
    [SerializeField] private Button _sellButton;
    [SerializeField] private Button _equipButton;

    private ShopItem _selectedItem;

    private void Start()
    {
        LeanTween.moveY(_containerHolder, 0, 1).setEaseOutBack();
        _playerCoinsText.text = PlayerInventory.Coins.ToString();
        ShowGoods();
    }

    public void SetShopKeeper(ShopKeeper keeper)
    {
        _shopKeeper = keeper;
    }

    public void ShowGoods()
    {
        ClearView();
        foreach(ClothesSO clothe in ShopGoods.Items)
        {
            Instantiate(_itemPrefab, _itemsHolder).GetComponent<ShopItem>().SetItemData(clothe, PlayerInventory, this);
        }
    }

    private void UpdateGoods()
    {
        _playerCoinsText.text = PlayerInventory.Coins.ToString();
        foreach (Transform child in _itemsHolder)
        {
            child.GetComponent<ShopItem>().UpdateItem(PlayerInventory);
        }
    }

    public void BuyItem()
    {
        if (_selectedItem != null && !PlayerInteractions.CanInteract)
        {
            _selectedItem.BuyItem(PlayerInventory);
            UpdateGoods();
        }
    }

    public void SellItem()
    {
        if (_selectedItem != null && !PlayerInteractions.CanInteract)
        {
            _selectedItem.SellItem(PlayerInventory);
            UpdateGoods();
        }
    }

    public void EquipItem()
    {
        if (_selectedItem != null && !PlayerInteractions.CanInteract)
        {
            _selectedItem.EquipItem(PlayerInventory);
        }
    }

    public void CloseShop()
    {
        _shopKeeper.EndInteraction();
        LeanTween.moveY(_containerHolder, -1100, 1).setEaseInBack().setOnComplete(()=>Destroy(gameObject));
    }

    public void SelectItem(ShopItem selected)
    {
        _selectedItem = selected;
        UpdateButtons();
    }

    private void ClearView()
    {
        foreach(Transform child in _itemsHolder)
        {
            Destroy(child.gameObject);
        }
    }

    private void UpdateButtons()
    {
        if (_selectedItem != null)
        {
            _sellButton.gameObject.SetActive(_selectedItem.ItemStatus == ShopItem.ShopItemStatus.AlreadyOwned);
            _equipButton.gameObject.SetActive(_selectedItem.ItemStatus == ShopItem.ShopItemStatus.AlreadyOwned);
            _buyButton.gameObject.SetActive(_selectedItem.ItemStatus != ShopItem.ShopItemStatus.AlreadyOwned);
            _buyButton.interactable = _selectedItem.ItemStatus == ShopItem.ShopItemStatus.CanBuy;
        }
    }
}
