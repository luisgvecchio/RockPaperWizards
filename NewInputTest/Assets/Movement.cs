using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    Rigidbody2D rigidBody;

    InputEditor jumpInput;
    InputAction jumpAct;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();

        jumpInput = new InputEditor();
        jumpAct = jumpInput.Base.Jump;
        jumpAct.Enable();
        

        jumpInput.Base.Jump.performed += OnJump;
    }

    private void OnJump(InputAction.CallbackContext obj)
    {
        rigidBody.AddForce(Vector3.up * 1, ForceMode2D.Impulse);
    }

}
