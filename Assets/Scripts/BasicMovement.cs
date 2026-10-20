using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class BasicMovement : MonoBehaviour
{
    Vector2 playerPosition;
    Rigidbody2D myRigidbody2D;
    [SerializeField] float playerSpeed;
    InputAction moveAction;

    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        TestMove();
    }
    public void OnMove (InputValue value)
    {
        playerPosition = value.Get<Vector2>();
        Debug.Log(playerPosition);
    }   
    void TestMove()
    {
        Vector2 PlayerSpeed = new Vector2(playerPosition.x*10f, myRigidbody2D.linearVelocity.y);
        myRigidbody2D.linearVelocity = PlayerSpeed;
    }

    public void OnJump(InputValue value)
    {
        if(value.isPressed)
        {
            Debug.Log("GETSUGA... TENSHOOOOOOOOO!");
        }
    }
}
