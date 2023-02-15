using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraLook : MonoBehaviour
{
    // Camera attached to player
    public Camera playerCamera;

    // Mouse delta values
    public float deltaX;
    public float deltaY;

    // Players rotation
    public float playerRotX; // x axis in degrees
    public float playerRotY; // y axis in degrees

    public float sensitivity = 100f;

    // Start is called before the first frame update
    void Start()
    {
        playerCamera = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        deltaX = 0;
        playerRotX = 0;
        playerRotY = 0;
    }

    // Update is called once per frame
    void Update()
    {
        playerRotY += deltaX * sensitivity * Time.deltaTime;
        playerRotX -= deltaY * sensitivity * Time.deltaTime;

        // clamp on x axis
        playerRotX = Mathf.Clamp(playerRotX, -90f, 45f);

        // update camera
        playerCamera.transform.localRotation = Quaternion.Euler(playerRotX, 0, 0);
        transform.rotation = Quaternion.Euler(0, playerRotY, 0);
    }

    public void OnLook(InputValue inputValue)
    {
        Vector2 inputVector = inputValue.Get<Vector2>();
        deltaX = inputVector.x;
        deltaY = inputVector.y;
    }
}
