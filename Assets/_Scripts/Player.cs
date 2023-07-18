using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Player : NetworkBehaviour
{
    [Header("External References")]
    [SerializeField] private Transform _body;
    public SkinSO Skin;
    [SerializeField] private SpriteRenderer _bodyRenderer;
    [SerializeField] private SpriteRenderer _leftHandRenderer;
    [SerializeField] private SpriteRenderer _rightHandRenderer;

    // Properties
    public Vector3 Position => _body.transform.position;
    public bool Ragdoll { get; set; }
    public float PullStrength;

    // Component References
    [SerializeField] private HandMagnet _leftHand;
    [SerializeField] private HandMagnet _rightHand;

    void Start() {
        _leftHand.Initialize(this, 5.0f);
        _rightHand.Initialize(this, 5.0f);
        SetSkin();
    }

    private void SetSkin() {
        _leftHandRenderer.sprite = Skin.LeftHand;
        _rightHandRenderer.sprite = Skin.RightHand;
        _bodyRenderer.sprite = Skin.Body;
    }
}