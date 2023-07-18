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
    [SerializeField] private Rigidbody2D _coreRigidbody;

    [Header("Properties")]
    [HideInInspector] private float _maxDistance;
    private float _maxDelta;

    public void Initialize(Player player, float maxDistance) {
        _player = player;
        _maxDistance = maxDistance;
        _maxDelta = maxDistance / 2.0f;
    }

    protected override void FixedUpdate() {
        if (_player == null || !_player.isLocalPlayer) {
            return;
        }

        if (MagnetOn && !_player.Ragdoll) {
            Magnetize();
        } else {
            PullBody();
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

        Vector2 handToTarget = targetPos - handPos;

        if (handToTarget.magnitude < _maxDelta) {
            transform.position = targetPos;
        } else {
            transform.position = (Vector2)transform.position + (handToTarget / handToTarget.magnitude * _maxDelta);
        }
    }

    private void PullBody() {
        Vector2 shoulderPos = new Vector2(_shoulderTransform.position.x, _shoulderTransform.position.y);
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 shoulderToMouse = mousePos - shoulderPos;

        _coreRigidbody.AddForce(shoulderToMouse * _player.PullStrength);
    }
}