using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingIcons : MonoBehaviour
{
    void Start()
    {
        LeanTween.moveY(gameObject, transform.position.y + .3f, .5f).setEaseOutCubic().setLoopPingPong();
    }
}
