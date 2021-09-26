using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseCanvas : MonoBehaviour
{
    private void Start()
    {
        SoundManager.Instance.PlaySound(SoundManager.Instance.Sounds.OpenMenuSound);
        LeanTween.scaleY(gameObject, 1, .2f).setOnComplete( ()=> PlayerInteractions.SetPlayerInteracting(true) );
    }

    public void Quit()
    {
        SoundManager.Instance.PlaySound(SoundManager.Instance.Sounds.ClickSound);
        Application.Quit();
    }

    public void Close()
    {
        SoundManager.Instance.PlaySound(SoundManager.Instance.Sounds.ClickSound);
        PlayerInteractions.SetPlayerInteracting(false);
        LeanTween.scaleY(gameObject, 0, .2f).setOnComplete(() => Destroy(transform.parent.gameObject));
    }
}
