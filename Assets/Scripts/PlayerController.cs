using UnityEngine;
using CharacterControllers;


[RequireComponent(typeof(CharacterController2D))]
public class PlayerController : MonoBehaviour 
{
    private CharacterController2D _controller;
    private InputHandler _inputHandler;
    private Vector2 _moveInput;
        
    private void Awake()
    {
        _inputHandler = new InputHandler();
        _inputHandler.jumpEvent += Jump;
        _inputHandler.actionEvent += ActionEvent;
        _controller = GetComponent<CharacterController2D>();
    }

    private void FixedUpdate()
    {
        _moveInput = new Vector2(_inputHandler._moveInput,0);
        _controller.Move(_moveInput);
   }

    private void Jump()
    {
        _controller.Jump(_moveInput.x); 
    }

    private void ActionEvent()
    {
        
    }
}
