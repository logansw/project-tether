using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// (Blob component)
/// Climbing hold
/// </summary>
public class Holdable : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Collider2D _collider;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    // [SerializeField] private HoldTimer _holdTimerPrefab;

    [Header("Properties")]
    // [SerializeField] private float _duration;
    // [SerializeField] private bool _safeHold;

    // public HoldTimer HoldTimer;
    private Color32 _color;

    public void Initialize() {
        // SetColor(color);
        // HoldTimer.Initialize(_duration, new Color32(255, 255, 255, 255));
    }

    public void Awake() {
        _collider = GetComponent<Collider2D>();
    }

    public void Enable() {
        _collider.enabled = true;
        _color.a = 255;
        _spriteRenderer.color = _color;
        // HoldTimer.RefreshTimer();
    }
    public void Disable() {
        _collider.enabled = false;
        _color.a = 100;
        _spriteRenderer.color = _color;
    }

    // public void SetColor(Route.ColorGrade color) {
    //     switch (color) {
    //         case Route.ColorGrade.Yellow:
    //             _color = new Color32(255, 211, 55, 255);
    //             break;
    //         case Route.ColorGrade.Red:
    //             _color = new Color32(237, 86, 86, 255);
    //             break;
    //         case Route.ColorGrade.Green:
    //             _color = new Color32(41, 173, 70, 255);
    //             break;
    //         case Route.ColorGrade.Purple:
    //             _color = new Color32(125, 122, 159, 255);
    //             break;
    //         case Route.ColorGrade.Orange:
    //             _color = new Color32(248, 152, 41, 255);
    //             break;
    //         case Route.ColorGrade.Black:
    //             _color = new Color32(59, 59, 59, 255);
    //             break;
    //         case Route.ColorGrade.Blue:
    //             _color = new Color32(45, 190, 190, 255);
    //             break;
    //         case Route.ColorGrade.Pink:
    //             _color = new Color32(241, 101, 193, 255);
    //             break;
    //         case Route.ColorGrade.White:
    //             _color = new Color32(255, 255, 255, 255);
    //             break;
    //     }
    //     _spriteRenderer.color = _color;
    // }

    // public void DisplayTimer(bool active) {
    //     if (HoldTimer != null && !_safeHold) {
    //         HoldTimer.gameObject.SetActive(active);
    //     }
    // }
}