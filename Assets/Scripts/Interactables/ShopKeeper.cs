using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
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
