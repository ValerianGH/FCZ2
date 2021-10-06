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
    private Vector2 direction;

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
        direction = obj.ReadValue<Vector2>();
        animator.SetBool("moving", true);
        animator.SetFloat("Vertical", direction.y);
        animator.SetFloat("Horizontal", direction.x);
    }

    private void MoveCanceled(InputAction.CallbackContext obj)
    {
        direction = Vector2.zero;
        animator.SetBool("moving", false);
        animator.SetFloat("Vertical", direction.y);
        animator.SetFloat("Horizontal", direction.x);
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
        if(rb2D.velocity.magnitude < maxspeed)
        {
            rb2D.AddForce(direction * speed * direction.magnitude);
        }
    }
}
