using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// (Input component)
/// Parent class for components which move towards the mouse.
/// </summary>
public abstract class MouseMagnet : MonoBehaviour
{
    protected Player _player;
    public bool MagnetOn;

    public void Initialize(Player player) {
        _player = player;
    }

    // Update is called once per frame
    protected virtual void FixedUpdate()
    {
        if (MagnetOn && !_player.Ragdoll) {
            Magnetize();
        }
    }

    public abstract void Magnetize();
}