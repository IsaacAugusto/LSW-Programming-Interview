using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class BankInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private InventorySO _playerInventory;

    public void EndInteraction()
    {
        PlayerInteractions.SetPlayerInteracting(false);
        SoundManager.Instance.PlaySound(SoundManager.Instance.Sounds.ClickSound);
    }

    public void Interact()
    {
        PlayerInteractions.SetPlayerInteracting(true);
        OpenBank();
    }

    private void OpenBank()
    {
        Instantiate(Resources.Load<GameObject>("BankCanvas")).GetComponent<BankCanvas>().SetInteractableAndInventory(this, _playerInventory);
        SoundManager.Instance.PlaySound(SoundManager.Instance.Sounds.OpenMenuSound);
    }
}
