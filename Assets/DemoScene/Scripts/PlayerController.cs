using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    private PlayerActions inputActions;
    public GameData gameData;

    private Vector2 moveInput;

    [SerializeField] private float speed = 50;
    [SerializeField] private float acceleration = 20;

    // Appeler en premier avant meme le Start()
    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        // Recupere la réference au rigidbody et désactive la gravité
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;

        // Crée un nouveau Player actions, pour pourvoir récuperer les inputs du joueurs
        inputActions = new PlayerActions();
        inputActions.Enable();

        LinkActions();
    }

    private void Start()
    {
        gameData = GameData.Instance;
    }

    void LinkActions()
    {
        // Lie les actions du player input au fonctions correspondantes 
        inputActions.PlayerInput.Move.started += OnMove; //started correspond a quand le joueur apuis sur le bouton
        inputActions.PlayerInput.Move.performed += OnMove; //performed correspond a quand la valeur change (surtout utile avec les input de joystick)
        inputActions.PlayerInput.Move.canceled += OnMove; //canceled correspond a quand le joueur relache le bouton
    }

    private void Update()
    {
        // Envoie la vitesse
        animator.SetFloat("Speed", moveInput.sqrMagnitude);

        // Envoie la direction
        if (moveInput != Vector2.zero)
        {
            animator.SetFloat("MoveX", moveInput.x);
            animator.SetFloat("MoveY", moveInput.y);
        }
    }

    // Fixed update est appelé a chaque update du moteur physique. Il est preférable de modifier a ce moment les positions des objects physiques
    void FixedUpdate()
    {
        // Calcule de la nouvelle vélocité en fonction de input du joueur
        Vector2 newVelocity = Vector2.Lerp(rb.linearVelocity, moveInput * speed, Time.fixedDeltaTime * acceleration);
        rb.linearVelocity = newVelocity;
    }

    void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

        if (!gameData.isGameStarted)
        {
            gameData.isGameStarted = true;

            StartCoroutine(CloseDoor());
        } 
    }

    public IEnumerator CloseDoor()
    {
        yield return new WaitForSeconds(0.5f);
        gameData.door.GetComponentInChildren<SpriteRenderer>().sprite = gameData.spriteCloseDoor;
        gameData.door.GetComponent<BoxCollider2D>().enabled = true;
        yield break;
    }
}
