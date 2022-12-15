using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // EXPORT VARS
    public CharacterController controller;
    public float speed = 6f;
    public float gravity = 0.01f;

    //HP
    public int maxHealth = 100;
    public int currentHealth;

    public Health healthBar;

    // SPRITE MANAGERS
    private SpriteRenderer sprite;

    // CONTROLLER MANAGERS
    private InputControlller inpCon;

    // PRIVATE VARS (HELPERS)
    private bool isFlipped = false;

    // -------------------------------------------------------------------------------------------- BASIC METHODS

    private void Start()
    {
        // basic setup
        controller = GetComponent<CharacterController>();
        sprite = GetComponent<SpriteRenderer>();

        // KEYBOARD
        inpCon = new InputControlller();
        inpCon.Enable();

        //HP
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }



    private void Update()
    {
        Vector2 inputVector = inpCon.Player.Movement.ReadValue<Vector2>() * speed * Time.deltaTime;
        controller.Move(new Vector3(inputVector.x, -gravity * Time.deltaTime, inputVector.y));
        if (inputVector.x == 0){
            sprite.flipX = isFlipped;
        }
        else { 
            sprite.flipX = inputVector.x < 0;
            isFlipped = sprite.flipX;
        }

        //TestZone for losing hp
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }*/
    }
    // -------------------------------------------------------------------------------------------- CUSTOM METHODS

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealh(currentHealth);
    }
}
