using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float maxspeed;
    [SerializeField] private int damages;
    [SerializeField] private Transform SpawnPoint;
    [SerializeField] private Transform HitboxG;
    [SerializeField] private Transform HitboxD;
    [SerializeField] private Transform HitboxU;
    [SerializeField] private Transform HitboxB;

    private Animator animator;
    private Rigidbody2D rb2D;
    private Controls controls;
    private Vector2 direction;
    public Transform attackPoint;
    public LayerMask enemyLayers;
    public float attackRange = 0.5f;

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
        if(HitboxD == true)
        {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(HitboxB.position, attackRange, enemyLayers);
            foreach (Collider2D enemy in hitEnemies)
            {
                GetComponent<HPManager>();
                enemy.GetComponent<HPManager>().HP -= damages;
            }
        }
        else if (HitboxG == true)
        {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(HitboxB.position, attackRange, enemyLayers);
            foreach (Collider2D enemy in hitEnemies)
            {
                GetComponent<HPManager>();
                enemy.GetComponent<HPManager>().HP -= damages;
            }
        }
        else if (HitboxB == true)
        {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(HitboxB.position, attackRange, enemyLayers);
            foreach (Collider2D enemy in hitEnemies)
            {
                GetComponent<HPManager>();
                enemy.GetComponent<HPManager>().HP -= damages;
            }
        }
        else if (HitboxU == true)
        {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(HitboxB.position, attackRange, enemyLayers);
            foreach (Collider2D enemy in hitEnemies)
            {
                GetComponent<HPManager>();
                enemy.GetComponent<HPManager>().HP -= damages;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    private void Update()
    {
        Debug.Log(direction);
        if (direction == Vector2.down)
        {
                   }
    }

    void FixedUpdate()
    {   
        if(rb2D.velocity.magnitude < maxspeed)
        {
            rb2D.AddForce(direction * speed * direction.magnitude);
        }
    }
}
