using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Sounds")]
public class SoundsSO : ScriptableObject
{
    public AudioClip ClickSound;
    public AudioClip HoverButtonSound;
    public AudioClip CoinSound;
    public AudioClip EquipSound;
    public AudioClip OpenStoreSound;
    public AudioClip OpenMenuSound;
}
