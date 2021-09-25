using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Text _priceText;
    private int _price;

    public void SetItemData(ClothesSO clothe, int playerCoins)
    {
        _image.sprite = clothe.Sprite;
        _price = clothe.Price;
        _priceText.text = _price.ToString();

        CheckCanBuy(playerCoins);
    }

    private void CheckCanBuy(int playerCoins)
    {
        if (playerCoins < _price)
        {
            _priceText.color = Color.red;
        }
        else
        {
            _priceText.color = Color.white;
        }
    }
}
