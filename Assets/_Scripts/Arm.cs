using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm : MonoBehaviour
{
    [SerializeField] private HandMagnet _handMagnet;
    [SerializeField] private Transform _tether;
    public float Length { get; private set; }
    public float Rotation { get; private set; }
    private Vector3 _handPosition => _handMagnet.transform.position;

    public void Update() {
        OrientHand();
        OrientTether();
    }

    private void OrientHand() {
        Vector3 direction = _handPosition - transform.position;
        _handMagnet.transform.up = direction;
    }

    private void OrientTether() {
        Vector3 direction = _handPosition - _tether.position;
        _tether.transform.right = direction;
        _tether.localScale = new Vector3(direction.magnitude, 1, 1);
    }
}
