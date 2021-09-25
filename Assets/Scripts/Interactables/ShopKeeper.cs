using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeper : MonoBehaviour, IInteractable
{
    public void EndInteraction()
    {
        PlayerInteractions.SetPlayerInteracting(false);
    }

    public void Interact()
    {
        OpenShop();
    }

    private void OpenShop()
    {
        Instantiate(Resources.Load<GameObject>("ShopCanvas")).GetComponent<ShopManager>().SetShopKeeper(this);
    }
}
