using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public ShopInventory ShopGoods;
    public InventorySO PlayerInventory;

    [SerializeField] private Text _playerCoinsText;
    [SerializeField] private RectTransform _itemsHolder;
    [SerializeField] private GameObject _itemPrefab;

    private void Start()
    {
        _playerCoinsText.text = PlayerInventory.Coins.ToString();
        ShowGoods();
    }

    public void ShowGoods()
    {
        ClearView();
        foreach(ClothesSO clothe in ShopGoods.Items)
        {
            Instantiate(_itemPrefab, _itemsHolder).GetComponent<ShopItem>().SetItemData(clothe, PlayerInventory.Coins);
        }
    }

    private void ClearView()
    {
        foreach(Transform child in _itemsHolder)
        {
            Destroy(child.gameObject);
        }
    }
}
