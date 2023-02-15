using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Vector2 movementValue;

    void Update()
    {

        transform.Translate(
            movementValue.x * Time.deltaTime,
            0,
            movementValue.y * Time.deltaTime
        );

    }

    public void OnMove(InputValue value) {
        movementValue = value.Get<Vector2>() * speed;
    }
}
