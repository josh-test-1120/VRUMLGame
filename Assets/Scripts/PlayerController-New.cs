using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Google.XR.Cardboard;

public class PlayerControllerNew : MonoBehaviour
{
    // Public variables
    // The player transform component
    public Transform vrPlayer;
    // Forward movement angles
    public float backwardWalkAngle = 10.0f;
    public float backwardSprintAngle = 20.0f;
    public float backwardWowAngle = 45.0f;

    // Backward movement angles
    public float forwardWalkAngle = 350.0f;
    public float forwardSprintAngle = 340.0f;
    public float forwardWowAngle = 315.0f;

    // Speeds
    public float walkSpeed = 3.0f;
    public float sprintSpeed = 9.0f;
    public float wowSpeed = 50.0f;
    // Constants for movement
    public bool moveForward;
    public bool moveBackward;
    public bool isInverted = false;

    // Private variables
    // Import the character controller for collisions
    private CharacterController charControl;
    private float speed;
    private int buttonPressCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        charControl = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Api.IsTriggerPressed)
        //{
        //    Debug.Log("Button Pressed");
            
        //}
        //if (Api.IsTriggerHeldPressed)
        //{
        //    Debug.Log("Button Pressed and held");
        //    Debug.Log("Swapping to movement mode...");
        //    // Create a Vector3 and apply a conversion for movement delta
        //    Vector3 forward = vrPlayer.TransformDirection(Vector3.forward);
        //    // Tell the Character Controller for the Player GameObject to move
        //    charControl.SimpleMove(forward * speed);
        //}
        //// Boolean check for angle that would make you horizontal
        //bool notHorizontal = vrPlayer.eulerAngles.x < 90.0f;
        //// Initialize variables
        //speed = 0.0f;
        //moveForward = false;
        //moveBackward = false;
        //// Inverted movement response TODO
        //if (isInverted)
        //{
        //    if (vrPlayer.eulerAngles.x < 90.0f) ForwardChecks(inverted: true);
        //    if (vrPlayer.eulerAngles.x > 270.0f && vrPlayer.eulerAngles.x < 360.0f) BackwardChecks(inverted: true);
        //}
        //// Regular movement response
        //else
        //{
        //    if (vrPlayer.eulerAngles.x < 90.0f) BackwardChecks();
        //    if (vrPlayer.eulerAngles.x > 270.0f && vrPlayer.eulerAngles.x < 360.0f) ForwardChecks();
        //}
        
        //// Handle forward movement
        //if (moveForward == true)
        //{
        //    // Create a Vector3 and apply a conversion for movement delta
        //    Vector3 forward = vrPlayer.TransformDirection(Vector3.forward);
        //    // Tell the Character Controller for the Player GameObject to move
        //    charControl.SimpleMove(forward * speed);
        //}
        //// Handle backward movement
        //if (moveBackward == true)
        //{
        //    // Create a Vector3 and apply a conversion for movement delta
        //    Vector3 forward = vrPlayer.TransformDirection(Vector3.back);
        //    // Tell the Character Controller for the Player GameObject to move
        //    charControl.SimpleMove(forward * speed);
        //}
    }

    private void ForwardChecks(bool inverted=false)
    {
        // Regular Y axis control
        if (!inverted)
        {
            // God mode speed (development testing)
            if (vrPlayer.eulerAngles.x <= forwardWowAngle)
            {
                moveForward = true;
                speed = wowSpeed;
            }
            else if (vrPlayer.eulerAngles.x <= forwardSprintAngle)
            {
                moveForward = true;
                speed = sprintSpeed;
            }
            else if (vrPlayer.eulerAngles.x <= forwardWalkAngle)
            {
                moveForward = true;
                speed = walkSpeed;
            }
        }
        // Inverted Y axis control
        else
        {
            if (vrPlayer.eulerAngles.x >= forwardWalkAngle)
            {
                moveForward = true;
                speed = walkSpeed;
            }
            else if (vrPlayer.eulerAngles.x >= forwardSprintAngle)
            {
                moveForward = true;
                speed = sprintSpeed;
            }
            // God mode speed (development testing)
            else if (vrPlayer.eulerAngles.x >= forwardWowAngle)
            {
                moveForward = true;
                speed = wowSpeed;
            }
        }
    }

    private void BackwardChecks(bool inverted = false)
    {
        // Regular Y axis control
        if (!inverted)
        {
            if (vrPlayer.eulerAngles.x >= backwardSprintAngle)
            {
                moveBackward = true;
                speed = sprintSpeed;
            }
            else if (vrPlayer.eulerAngles.x >= backwardWalkAngle)
            {
                moveBackward = true;
                speed = walkSpeed;
            }
        }
        // Inverted Y axis control
        else
        {
            if (vrPlayer.eulerAngles.x <= backwardWalkAngle)
            {
                moveBackward = true;
                speed = walkSpeed;
            }
            else if (vrPlayer.eulerAngles.x <= backwardSprintAngle)
            {
                moveBackward = true;
                speed = sprintSpeed;
            }

        }

    }
}
