using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick : MonoBehaviour
{
    void Update() {
        HandleInput();
    }

    private void HandleInput() {
        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);

        }
    }
}
