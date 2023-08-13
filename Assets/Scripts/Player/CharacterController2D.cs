using PlayerStates;
using TMPro;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    public PlayerData playerData;
    public float speed = 4f;
    public TextMeshProUGUI currentGoldText;
    public InteractableProp prop;

    [Header("Body Parts Skinable")]
    public SpriteRenderer face;
    public SpriteRenderer hood;
    public SpriteRenderer shirt;
    public SpriteRenderer pants;

    [Header("UI")]
    public GameObject clothesInventoryUI;

    private Animator animator;
    private float horizontalDirection;
    private float verticalDirection;
    private Rigidbody2D rb;
    private StateMachine stateMachine;

    private void Awake()
    {
        // Get the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
        // Get the Animator component
        animator = GetComponent<Animator>();

        // If state machine is not initialized
        if (stateMachine == null)
        {
            // Create a new state machine
            stateMachine = new StateMachine();

            // Register states in the state machine
            stateMachine.RegistryNewState("Idle", new Idle(stateMachine, animator));
            stateMachine.RegistryNewState("WalkSide", new WalkSide(stateMachine, animator));
            stateMachine.RegistryNewState("WalkUpDown", new WalkUpDown(stateMachine, animator));
            stateMachine.RegistryNewState("Run", new Run(stateMachine, animator));
            stateMachine.RegistryNewState("Attack", new Attack(stateMachine, animator));
            stateMachine.RegistryNewState("AttackDown", new AttackDown(stateMachine, animator));
            stateMachine.RegistryNewState("Hit", new Hit(stateMachine, animator));
            stateMachine.RegistryNewState("Death", new Death(stateMachine, animator));

            // Set initial state to "Idle"
            stateMachine.ChangeState("Idle");
        }
    }

    private void Update()
    {
        // Get horizontal input direction
        horizontalDirection = Input.GetAxisRaw("Horizontal");
        // Get vertical input direction
        verticalDirection = Input.GetAxisRaw("Vertical");
        // Update current gold text
        currentGoldText.text = $"${playerData.currentGold}";

        // If moving left
        if (horizontalDirection < 0)
        {
            // Change to "WalkSide" state
            stateMachine.ChangeState("WalkSide");
            // Flip character horizontally
            transform.localScale = new Vector2(-Mathf.Abs(transform.localScale.x), transform.localScale.y);
        }
        // If moving right
        else if (horizontalDirection > 0)
        {
            // Change to "WalkSide" state
            stateMachine.ChangeState("WalkSide");
            // Flip character horizontally
            transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
        }
        // If moving up or down
        else if (verticalDirection != 0)
        {
            // Change to "WalkUpDown" state
            stateMachine.ChangeState("WalkUpDown");
        }

        // If "I" key is pressed down
        if (Input.GetKeyDown(KeyCode.I))
        {
            // Open the inventory
            clothesInventoryUI.SetActive(!clothesInventoryUI.activeInHierarchy);
        }

        // If "E" key is pressed down
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (prop == null)
            {
                return;
            }

            // Interact with chest 
            playerData.currentGold += 100;
            prop.DestroyProp();
        }
    }

    private void FixedUpdate()
    {
        if (horizontalDirection != 0 || verticalDirection != 0) // If moving in any direction
        {
            // Set velocity based on input direction and speed 
            rb.velocity = new Vector2(horizontalDirection * speed, verticalDirection * speed);

        }
        else
        {
            // Change to "Idle" state if not moving in any direction
            stateMachine.ChangeState("Idle");
            // Set velocity to zero if not moving in any direction
            rb.velocity = new Vector2(0, 0);
        }
    }
}
