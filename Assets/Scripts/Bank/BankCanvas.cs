using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BankCanvas : MonoBehaviour
{
    [SerializeField] private GameObject _painel;
    [SerializeField] private Text _coinsText;
    private BankInteractable _bankInteractable;
    private InventorySO _playerInventory;

    public void SetInteractableAndInventory(BankInteractable bank, InventorySO playerInventory)
    {
        _bankInteractable = bank;
        _playerInventory = playerInventory;
    }

    void Start()
    {
        LeanTween.moveY((RectTransform)_painel.transform, 0, 1).setEaseOutBack();
        UpdateCoinsText();
    }

    public void Close()
    {
        _bankInteractable.EndInteraction();
        LeanTween.moveY((RectTransform)_painel.transform, -1100, 1).setEaseInBack().setOnComplete(() => Destroy(gameObject));
    }

    public void AddCoinsButton()
    {
        _playerInventory.AddCoins(10);
        UpdateCoinsText();
    }

    public void ReduceCoinsButton()
    {
        _playerInventory.ReduceCoins(10);
        UpdateCoinsText();
    }

    private void UpdateCoinsText()
    {
        _coinsText.text = _playerInventory.Coins.ToString();
    }

}
