using UnityEngine;
using Rewired;
using System.Collections.Generic;

public class RotateFloorArrow  : MonoBehaviour
{
    [SerializeField] private int playerId = 0; // Rewired player ID
    private Player player; // Rewired player instance
    public float rotateSpeed;
    public GameObject _arrowFloor;
    void Start()
    {
        // Get the Rewired Player object for this player ID
        player = ReInput.players.GetPlayer(playerId);
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if(player.controllers.GetLastActiveController().type == ControllerType.Joystick)
{
            // Player is using a controller
            _arrowFloor.gameObject.SetActive(false);
        }
    else
        {
            // Player is using keyboard/mouse
            _arrowFloor.gameObject.SetActive(true);
            GetInput();
        }
    }

    private void GetInput()
    {
        // Get movement input from Rewired
        float rotatingInput = -player.GetAxisRaw("RotateMouse");


        // Check if there is any input
        if (rotatingInput != 0f)
        {
            Debug.Log("Rotating");

            // Apply rotation around the Y axis
            transform.Rotate(Vector3.forward * rotatingInput * rotateSpeed * Time.deltaTime);
        }
    }
}
