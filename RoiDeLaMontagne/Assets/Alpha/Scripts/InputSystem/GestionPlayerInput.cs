using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class GestionPlayerInput : MonoBehaviour
{
    private PlayerInputActions playerInputActions;

    [SerializeField]
    private Vector2 move;

    public float moveHorizontal;
    public float moveVertical;

    //
    public bool isPushing;
    public bool isAttracting;
    //

    public UnityEvent jump;

    private void Awake() 
    {
        playerInputActions = new PlayerInputActions();

        //Pour se déplacer
        playerInputActions.Player.Movement.performed += SeeMove;
        playerInputActions.Player.Movement.canceled += SeeMove;

        //Pour le saut
        playerInputActions.Player.Jump.started += SeeJump;

        //Pour repousser
        playerInputActions.Player.Push.started += SeePush;
        playerInputActions.Player.Push.canceled += SeePush;

        //Pour attirer
        playerInputActions.Player.Suck.started += SeeSuck;
        playerInputActions.Player.Suck.canceled += SeeSuck;

    }

    private void OnEnable()
    {
        playerInputActions.Player.Enable();
    }

    private void OnDisable()
    {
        playerInputActions.Player.Disable();
    }

    private void SeeJump(InputAction.CallbackContext context)
    {
        jump.Invoke();
    }

    private void SeeMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();

        moveHorizontal = move.x;
        moveVertical = move.y;
    }

    private void SeePush(InputAction.CallbackContext context)
    {
        isPushing = context.ReadValueAsButton();
    }

    private void SeeSuck(InputAction.CallbackContext context)
    {
        isAttracting = context.ReadValueAsButton();
    }
}
