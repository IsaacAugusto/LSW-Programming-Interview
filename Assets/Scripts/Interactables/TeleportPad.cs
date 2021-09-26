using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class TeleportPad : MonoBehaviour, IInteractable
{
    public int SceneID;

    public void EndInteraction()
    {
        
    }

    public void Interact()
    {
        PlayerInteractions.SetPlayerInteracting(true);
        Instantiate(Resources.Load<GameObject>("TeleportCanvas")).GetComponent<TeleportCanvas>().SetSceneIDAndLoad(SceneID);
    }
    
}
