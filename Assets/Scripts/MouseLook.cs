using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    // Enums for Rotation types
    public enum RotationAxes
    {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }
    // Default view
    public RotationAxes axes = RotationAxes.MouseXAndY;
    // Public variables
    public float sensitivityHor = 9.0f;
    public float sensitivityVert = 9.0f;
    public float minimumVert = -45.0f;
    public float maximumVert = 45.0f;
    private float verticalRot = 0;
    private float horizontalRot = 0;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null)
        {
            body.freezeRotation = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Mouse X movement rotations
        if (axes == RotationAxes.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);
        }
        // Mouse Y movement transformations
        else if (axes == RotationAxes.MouseY)
        {
            verticalRot -= Input.GetAxis("Mouse Y") * sensitivityVert;
            verticalRot = Mathf.Clamp(verticalRot, minimumVert, maximumVert);
            horizontalRot = transform.localEulerAngles.y;
            transform.localEulerAngles = new Vector3(verticalRot, horizontalRot, 0);
        }
        // Mouse X and Y movement transformations
        else
        {
            verticalRot -= Input.GetAxis("Mouse Y") * sensitivityVert;
            verticalRot = Mathf.Clamp(verticalRot, minimumVert, maximumVert);
            float delta = Input.GetAxis("Mouse X") * sensitivityHor;
            horizontalRot = transform.localEulerAngles.y + delta;
            transform.localEulerAngles = new Vector3(verticalRot, horizontalRot, 0);
        }
    }
}
