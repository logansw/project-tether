using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Moves hands towards mouse and orients limbs accordingly.
/// </summary>
public class HandMagnet : MouseMagnet
{
    [Header("References")]
    [SerializeField] private GameObject _ligament;
    [SerializeField] private Transform _shoulderTransform;

    [Header("Properties")]
    [HideInInspector] private float _maxDistance;

    public void Initialize(Player player, float maxDistance) {
        _player = player;
        _maxDistance = maxDistance;
    }

    protected override void FixedUpdate() {
        if (magnetOn && !_player.Ragdoll) {
            Magnetize();
        } else {
            // OrientLigament(_shoulderTransform.position, transform.position);
        }
    }

    /// <summary>
    /// Moves hand towards mouse
    /// </summary>
    public override void Magnetize()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 shoulderPos = new Vector2(_shoulderTransform.position.x, _shoulderTransform.position.y);
        Vector2 handPos = new Vector2(transform.position.x, transform.position.y);

        Vector2 shoulderToMouse = mousePos - shoulderPos;

        Vector2 targetPos;
        if (shoulderToMouse.magnitude > _maxDistance) {
            targetPos = shoulderPos + (shoulderToMouse / shoulderToMouse.magnitude * _maxDistance);
        } else {
            targetPos = mousePos;
        }

        transform.position = targetPos;
    }
}