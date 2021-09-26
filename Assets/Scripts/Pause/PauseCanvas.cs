using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseCanvas : MonoBehaviour
{
    private void Start()
    {
        LeanTween.scaleY(gameObject, 1, .2f).setOnComplete( ()=> PlayerInteractions.SetPlayerInteracting(true) );
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Close()
    {
        PlayerInteractions.SetPlayerInteracting(false);
        LeanTween.scaleY(gameObject, 0, .2f).setOnComplete(() => Destroy(transform.parent.gameObject));
    }
}
