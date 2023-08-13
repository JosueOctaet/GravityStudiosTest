using PlayerStates;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.XR;

public class CharacterController2D : MonoBehaviour
{
    public float speed = 4f;

    private Animator animator;
    private float horizontalDirection;
    private float verticalDirection;
    private Rigidbody2D rb;
    private StateMachine stateMachine;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        if (stateMachine == null)
        {
            stateMachine = new StateMachine();

            stateMachine.RegistryNewState("Idle", new Idle(stateMachine, animator));
            stateMachine.RegistryNewState("WalkSide", new WalkSide(stateMachine, animator));
            stateMachine.RegistryNewState("WalkUpDown", new WalkUpDown(stateMachine, animator));
            stateMachine.RegistryNewState("Run", new Run(stateMachine, animator));
            stateMachine.RegistryNewState("Attack", new Attack(stateMachine, animator));
            stateMachine.RegistryNewState("AttackDown", new AttackDown(stateMachine, animator));
            stateMachine.RegistryNewState("Hit", new Hit(stateMachine, animator));
            stateMachine.RegistryNewState("Death", new Death(stateMachine, animator));

            stateMachine.ChangeState("Idle");
        }
    }

    private void Update()
    {
        horizontalDirection = Input.GetAxisRaw("Horizontal");
        verticalDirection = Input.GetAxisRaw("Vertical");

        if (horizontalDirection < 0)
        {
            stateMachine.ChangeState("WalkSide");
            transform.localScale = new Vector2(-Mathf.Abs(transform.localScale.x), transform.localScale.y);
        }
        else if (horizontalDirection > 0)
        {
            stateMachine.ChangeState("WalkSide");
            transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
        }
        else if (verticalDirection != 0)
        {
            stateMachine.ChangeState("WalkUpDown");
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            stateMachine.ChangeState("Attack");
        }
    }

    private void FixedUpdate()
    {
        if (horizontalDirection != 0 || verticalDirection != 0)
        {
            rb.velocity = new Vector2(horizontalDirection * speed, verticalDirection * speed);
        }
        else
        {
            stateMachine.ChangeState("Idle");
            rb.velocity = new Vector2(0, 0);
        }
    }
}
