using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour
{
    // Public variables
    public float speed = 6.0f;
    public float gravity = -9.8f;
    // Private variables
    private CharacterController charController;
    private bool vertStopped;
    private bool HorzStopped;
    private int seconds;
    // Sprinting for quick movement in dev
    private int sprintTime = 1000;


    // Start is called before the first frame update
    void Start()
    {
        charController = GetComponent<CharacterController>();
        vertStopped = true;
        HorzStopped = true;
        seconds = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;

        // Auto-Sprint for developing and moving around faster
        if (deltaX != 0) seconds++;
        if (deltaZ != 0) seconds++;
        if (deltaX == 0 && deltaZ == 0) seconds = 0;

        if (seconds > sprintTime && deltaX != 0) deltaX *= 10;
        if (seconds > sprintTime && deltaZ != 0) deltaZ *= 10;

        Debug.Log("This is the seconds: " + seconds);

        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        //movement = Vector3.ClampMagnitude(movement, speed);

        movement.y = gravity;

        movement *= Time.deltaTime;

        // This causes rotation to induce movement. Removed
        movement = transform.TransformDirection(movement);
        charController.Move(movement);

    }
}
