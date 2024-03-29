using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    public static bool CanInteract;

    Collider2D[] _results = new Collider2D[5];

    void Start()
    {
        CanInteract = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact") && CanInteract)
        {
            Interact();
        }

        if (Input.GetButtonDown("Pause") && CanInteract)
        {
            Instantiate(Resources.Load<GameObject>("PauseCanvas"));
        }
    }

    /// <summary>
    /// Set if the player is current interacting with some menu or object to ignore player movement inputs and other interactions.
    /// </summary>
    public static void SetPlayerInteracting(bool value)
    {
        CanInteract = !value;
        PlayerBehaviour.CanMove = !value;
    }


    /// <summary>
    /// Look if theres any IInteractable in range and interact with it.
    /// </summary>
    private void Interact()
    {
        ClearResults();
        Physics2D.OverlapCircleNonAlloc(transform.position, 1, _results);
        foreach(Collider2D result in _results)
        {
            if (result != null && result.GetComponent<IInteractable>() != null)
            {
                result.GetComponent<IInteractable>().Interact();
                SetPlayerInteracting(true);
                return;
            }
        }
    }

    private void ClearResults()
    {
        for (int i = 0; i < _results.Length; i++)
        {
            _results[i] = null;
        }
    }
}
