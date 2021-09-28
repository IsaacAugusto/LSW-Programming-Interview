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
        SoundManager.Instance.PlaySound(SoundManager.Instance.Sounds.OpenStoreSound);
        _playerCoinsText.text = PlayerInventory.Coins.ToString();
        ShowGoods();
    }

    /// <summary>
    /// Link this shop with the shopkeeper that opened it.
    /// </summary>
    public void SetShopKeeper(ShopKeeper keeper)
    {
        _shopKeeper = keeper;
    }

    /// <summary>
    /// Show items that are available on the shop inventory.
    /// </summary>
    public void ShowGoods()
    {
        ClearView();
        foreach(ClothesSO cloth in ShopGoods.Items)
        {
            Instantiate(_itemPrefab, _itemsHolder).GetComponent<ShopItem>().SetItemData(cloth, PlayerInventory, this);
        }
    }

    /// <summary>
    /// Updates all available items visuals and states.
    /// </summary>
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
        SoundManager.Instance.PlaySound(SoundManager.Instance.Sounds.ClickSound);
        LeanTween.moveY(_containerHolder, -1100, 1).setEaseInBack().setOnComplete(()=>Destroy(gameObject));
    }

    public void SelectItem(ShopItem selected)
    {
        _selectedItem = selected;
        UpdateButtons();
    }

    /// <summary>
    /// Clear all itens on shop canvas.
    /// </summary>
    private void ClearView()
    {
        foreach(Transform child in _itemsHolder)
        {
            Destroy(child.gameObject);
        }
    }

    /// <summary>
    /// Update the shop actions buttons (buy, sell, equip) for the selected item.
    /// </summary>
    private void UpdateButtons()
    {
        if (_selectedItem != null)
        {

            _sellButton.gameObject.SetActive(_selectedItem.ItemStatus == ShopItem.ShopItemStatus.AlreadyOwned
                || _selectedItem.ItemStatus == ShopItem.ShopItemStatus.Equiped);

            _equipButton.gameObject.SetActive(_selectedItem.ItemStatus == ShopItem.ShopItemStatus.AlreadyOwned);

            _buyButton.gameObject.SetActive(_selectedItem.ItemStatus != ShopItem.ShopItemStatus.AlreadyOwned 
                && _selectedItem.ItemStatus != ShopItem.ShopItemStatus.Equiped);

            _buyButton.interactable = _selectedItem.ItemStatus == ShopItem.ShopItemStatus.CanBuy;

        }
    }
}
