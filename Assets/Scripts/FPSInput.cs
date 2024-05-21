using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour
{
    // Public variables
    public float baseSpeed = 6.0f;
    public float runSpeed = 250.0f;
    public float speed = 6.0f;
    public float gravity = -9.8f;
    public float jumpSpeed = 15.0f;
    public float terminalVelocity = -10.0f;
    public float minFall = -1.5f;
    // Private variables
    private CharacterController charController;
    // Sprinting for quick movement in dev
    private int sprintTime = 1000;
    private int jumpForce = 5;
    private bool IsGrounded;
    private float currentSpeed;
    private Vector3 movement;
    private float vertSpeed;


    // Message Listeners
    void OnEnable()
    {
        Messenger<float>.AddListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }
    void OnDisable()
    {
        Messenger<float>.RemoveListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }

    // Start is called before the first frame update
    void Start()
    {
        charController = GetComponent<CharacterController>();
        IsGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal");
        float deltaZ = Input.GetAxis("Vertical");

        //if (Input.GetKeyDown("space"))
        //{

        if (charController.isGrounded)
            {
                if (Input.GetButtonDown("Jump"))
                {
                    vertSpeed = jumpSpeed;
                }
                else
                {
                    vertSpeed = minFall;
                }
            }
            else
            {
                vertSpeed += gravity * 5 * Time.deltaTime;
                if (vertSpeed < terminalVelocity)
                {
                    vertSpeed = terminalVelocity;
                }
            }
            movement.y = vertSpeed;
            movement *= Time.deltaTime;
            charController.Move(movement);
            //if (IsGrounded == true)
            //{
            //    Debug.Log("Spacebar pressed");
            //    Rigidbody PlayerRB = GetComponent<Rigidbody>();
            //    PlayerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            //}
        //}
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            Debug.Log("Shift keys pressed");
            deltaX *= runSpeed;
            deltaZ *= runSpeed;
        }
        else
        {
            deltaX *= baseSpeed;
            deltaZ *= baseSpeed;
        }

        movement = new Vector3(deltaX, 0, deltaZ);

        movement.y = gravity;

        movement *= Time.deltaTime;

        // This causes rotation to induce movement. Removed
        movement = transform.TransformDirection(movement);
        charController.Move(movement);


    }

    private void OnSpeedChanged(float value)
    {
        speed = baseSpeed * value;
    }
}
