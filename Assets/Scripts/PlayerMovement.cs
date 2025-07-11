using UnityEngine;
using Rewired;
using System.Collections.Generic;
using UnityEngine.Windows;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private int playerId = 0; // Rewired player ID
    [SerializeField] private float moveSpeed = 5f; // Movement speed
    [SerializeField] private Camera isometricCamera; // Reference to the isometric camera

    //public playerInteraction _playerInteraction;
    private Player player; // Rewired player instance
    public GameObject HUD;

    [Header("Potions")]
    public int currentPotion = 0;

    [Header("Health")]
    public float _health;

    [Header("Attack")]
    public Animator _animatorAttack;
    public float attackDamage;

    [Header("Dodge")]
    public float speedDodge;
    public GameObject getRotationFromArrow;

    [Header("Speed")]
    public float AttackSpeed;

    [Header("Tutorial")]
    public bool isMoving = false;
    public int stepsList = 0;
    public List<GameObject> listTutorials;
    public GameObject headTutorial;

    // Start is called once before the first execution of Update
    void Start()
    {
        // Get the Rewired Player object for this player ID
        player = ReInput.players.GetPlayer(playerId);


        // If no camera is assigned, try to find the main camera
        if (isometricCamera == null)
        {
            isometricCamera = Camera.main;
        }
        _health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        Interact();
        //Tutorial();
    }
    private void GetInput()
    {
        // Get movement input from Rewired
        float horizontal = player.GetAxisRaw("MoveHorizontal"); // Replace with your Rewired action name
        float vertical = player.GetAxisRaw("MoveVertical"); // Replace with your Rewired action name

        // Check if there is any input
        if (horizontal != 0f || vertical != 0f)
        {
            Debug.Log("Moving");
            // Create a direction vector based on input
            Vector3 inputDirection = new Vector3(horizontal, 0f, vertical);

            // Convert input direction to isometric world space
            Vector3 worldDirection = CameraRelativeToIsometric(inputDirection);

            // Normalize direction to ensure consistent speed
            worldDirection.Normalize();

            // Move the player
            transform.Translate(worldDirection * moveSpeed * Time.deltaTime, Space.World);

            // Rotate the player to face the movement direction
            if(player.controllers.GetLastActiveController().type == ControllerType.Joystick)
{
                // Player is using a controller
                RotateToDirection(worldDirection);
            }
else
            {
                // Player is using keyboard/mouse
                // Do nothing
            }

        }

        if (player.GetButtonDown("Attack"))
        {
            Attack();
        }

        if (player.GetButtonDown("Dodge"))
        {
            Dodge();
        }

        if (player.GetButtonDown("NextPotion"))
        {
            changePotion(-1);
        } 
        else if (player.GetButtonDown("PreviousPotion"))
        {
            changePotion(1);
        }

        if (player.GetButtonDown("UsePotion"))
        {
            usePotion();
        }
    }

    // Converts input direction to isometric world space based on the camera
    private Vector3 CameraRelativeToIsometric(Vector3 inputDirection)
    {
        // Use the camera's forward and right vectors to calculate world movement
        Vector3 forward = isometricCamera.transform.forward;
        Vector3 right = isometricCamera.transform.right;

        // Project forward and right onto the XZ plane (ignore Y component)
        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        // Combine the right and forward vectors with the input direction
        return inputDirection.x * right + inputDirection.z * forward;
    }

    // Rotate the player to face the movement direction
    private void RotateToDirection(Vector3 direction)
    {
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
    }


    void Attack()
    {
        Debug.Log("ATTACK!");
        _animatorAttack.SetTrigger("Attack");
    }

    void Dodge()
    {
        Debug.Log("Dodge!");
        if (player.controllers.GetLastActiveController().type == ControllerType.Joystick)
        {
            this.GetComponent<Rigidbody>().AddForce(transform.forward*speedDodge, ForceMode.Impulse);
        }
        else
        {
            this.GetComponent<Rigidbody>().AddForce(-getRotationFromArrow.transform.up*speedDodge, ForceMode.Impulse);
        }
    }

    public void LoseHealth(float damageAmount)
    {
        _health -= damageAmount;
        Debug.Log("Player health: " + _health);

        if (_health <= 0)
        {
            Debug.Log("Player died!");
            // Add your death logic here (e.g., respawn, game over screen)
        }
    }

    void GainHealth()
    {

    }

    void GainSpeed()
    {

    }

    void GainDamage()
    {

    }

    private void changePotion(int _currentPotion)
    {
        currentPotion = currentPotion + _currentPotion;
        if (currentPotion < -1)
        {
            currentPotion = 1;
        }

        if (currentPotion > 1)
        {
            currentPotion = -1;
        }
        Debug.Log("Current potion: "+ currentPotion);
    }
    private void usePotion()
    {
        Debug.Log("I used a Potion");
        switch (currentPotion)
        {
            case 0:
                Debug.Log("Used Health Potion");
                GainHealth();
                break;

            case -1:
                Debug.Log("Used Stamina Potion");
                GainSpeed();
                break;

            case 1:
                Debug.Log("Used Strength Potion");
                GainDamage();
                break;
        }
    }
    public void Interact()
    {
        //if(player.GetButtonDown("Interact") == true && _playerInteraction.enterd == true)
        //{
        //    if (headTutorial.activeSelf == false)
        //    {
        //        this.enabled = false;
        //        HUD.SetActive(true);
        //    }
        //}
    }


    private void Tutorial()
    {
        switch (stepsList)
        {
            case 0:
                if (player.GetAxisRaw("MoveHorizontal") > 0 || player.GetAxisRaw("MoveVertical") > 0)
                {
                    listTutorials[stepsList].GetComponent<Animator>().SetBool("Moved", true);
                    stepsList++;
                }
                break;
            case 1:
                //if (player.GetButtonDown("Interact") == true && _playerInteraction.enterd == true)
                //{
                //    listTutorials[stepsList].GetComponent<Animator>().SetBool("Moved", true);
                //    stepsList++;
                //}
                break;
            case 2:
                if (player.GetButtonDown("NextTutorial") == true)
                {
                    listTutorials[stepsList].GetComponent<Animator>().SetBool("Moved", true);
                    stepsList++;
                }
                break;
            case 3:
                if (player.GetButtonDown("NextTutorial") == true)
                {
                    listTutorials[stepsList].GetComponent<Animator>().SetBool("Moved", true);
                    stepsList++;
                }
                break;
            case 4:
                if (player.GetButtonDown("NextTutorial") == true)
                {
                    listTutorials[stepsList].GetComponent<Animator>().SetBool("Moved", true);
                    stepsList++;
                }
                break;


        }

    }
}
