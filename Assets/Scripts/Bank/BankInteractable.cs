using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BankInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private InventorySO _playerInventory;

    public void EndInteraction()
    {
        PlayerInteractions.SetPlayerInteracting(false);

    }

    public void Interact()
    {
        PlayerInteractions.SetPlayerInteracting(true);
        OpenBank();
    }

    private void OpenBank()
    {
        Instantiate(Resources.Load<GameObject>("BankCanvas")).GetComponent<BankCanvas>().SetInteractableAndInventory(this, _playerInventory);
    }
}
