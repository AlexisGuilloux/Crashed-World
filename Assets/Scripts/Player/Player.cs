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
    }
    // -------------------------------------------------------------------------------------------- CUSTOM METHODS
}
