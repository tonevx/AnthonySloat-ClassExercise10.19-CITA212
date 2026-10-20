using UnityEngine;
using UnityEngine.InputSystem;

public class Start_Move : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float jumpHeight = 7f;

    Vector2 movePlayer;
    Rigidbody2D rb;
    BoxCollider2D feetCollider;
    bool isAlive = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        feetCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        Run();
    }

    public void OnMove(InputValue value)
    {
        movePlayer = value.Get<Vector2>();
    }

    void Run()
    {
        if(!isAlive)
        {
            return;
        }
        Vector2 playerVelocity = new Vector2(
            movePlayer.x * moveSpeed,
            rb.linearVelocity.y
        );
        rb.linearVelocity = playerVelocity;
    }

    public void OnJump(InputValue value)
    {
        if(!feetCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) 
        { 
            return;
        };
        if(!isAlive)
        {
           return; 
        }
        if(value.isPressed)
        {
            rb.linearVelocity += new Vector2(0f, jumpHeight);
            Debug.Log("GETSUGA... TENSHOOOOOOOOO!");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Enemy"))
        {
            isAlive = false;
            Debug.Log("Don't despair, Ichigo.");
        }
    }
}
