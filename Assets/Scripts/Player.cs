using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float maxspeed;

    private Animator animator;
    private Rigidbody2D rb2D;
    private Controls controls;
    private float direction;

    private void OnEnable()
    {
        controls = new Controls();
        controls.Enable();
        controls.Main.Move.performed += MovePerformed;
        controls.Main.Move.canceled += MoveCanceled;
        controls.Main.Attack.performed += AttackPerformed;
        controls.Main.Attack.canceled += AttackCanceled;
    }
    
    private void MovePerformed(InputAction.CallbackContext obj)
    {
        direction = obj.ReadValue<float>();
        animator.SetBool("moving", true);
    }

    private void MoveCanceled(InputAction.CallbackContext obj)
    {
        direction = 0;
        animator.SetBool("moving", false);
    }

    private void AttackPerformed(InputAction.CallbackContext obj)
    {
        Attacking();
        animator.SetBool("attacking", true);
    }
    private void AttackCanceled(InputAction.CallbackContext obj)
    {
        animator.SetBool("attacking", false);
    }

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Attacking()
    {
        
    }

    void FixedUpdate()
    {
        var horizontalSpeed = Mathf.Abs(rb2D.velocity.x);
        var verticalSpeed = Mathf.Abs(rb2D.velocity.y);
        if (horizontalSpeed < maxspeed && verticalSpeed < maxspeed);
        {
            rb2D.AddForce(new Vector2(speed * direction, 0));
        }
    }


}
