using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour, IInteractable
{
    [TextArea]
    public string Text;

    public void EndInteraction()
    {
        PlayerInteractions.SetPlayerInteracting(false);
        SoundManager.Instance.PlaySound(SoundManager.Instance.Sounds.ClickSound);
    }

    public void Interact()
    {
        PlayerInteractions.SetPlayerInteracting(false);
        Instantiate(Resources.Load<GameObject>("BoardCanvas")).GetComponent<BoardCanvas>().SetData(this, Text);
        SoundManager.Instance.PlaySound(SoundManager.Instance.Sounds.OpenMenuSound);
    }
}
