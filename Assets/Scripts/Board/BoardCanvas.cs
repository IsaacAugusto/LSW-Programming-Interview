using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Collider2D))]
public class BoardCanvas : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private GameObject _boardContainer;
    private Board _board;

    public void SetData(Board boardInteractable, string text)
    {
        _board = boardInteractable;
        _text.text = text;
    }

    void Start()
    {
        LeanTween.scaleY(_boardContainer, 1, .2f);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Interact") && !PlayerInteractions.CanInteract)
        {
            CloseBoard();
        }
    }

    public void CloseBoard()
    {
        _board.EndInteraction();
        LeanTween.scaleY(_boardContainer, 0, .2f).setOnComplete(() => Destroy(gameObject));
    }
}
